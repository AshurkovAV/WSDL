using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WSDLTest.Common;
using WSDLTest.Common.MessageInspector;
using WSDLTest.ServiceReference2;

namespace WSDLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Метод предназначен для тестирования работоспособности сервиса МО
            //MOHealthCheks();
            ProductCode code = new ProductCode();
            code.Code = "GD000449";
            code.Qualifier = "GenericDrug";
            code.Text = "Amoxycillini, капсулы, 500 мг";

            var medication = new List<RxMedication>();
            medication.Add(new RxMedication
            {
                DrugCoded = new DrugCoded
                {
                    Items = new object[] { code }
                },
            });
            medication.ToArray();
            //А в методе CancelRxTest проблема с обращением к DrugCoded
            CancelRxTest();
            Console.ReadKey();
        }
        static void MOHealthCheks()
        {
            ServiceReference2.MedicataMOV2PortClient client = new ServiceReference2.MedicataMOV2PortClient();
            var result = client.MOHealthCheck(new ServiceReference2.MOHealthCheckRequest()
            {
                PracticeLocation = new ServiceReference2.PracticeLocationType()
                {
                    Identification = new ServiceReference2.FacilityID()
                    {
                        ID = "3220101",
                        MedicareNumber = "3220101",
                        Ogrn = "1023101681745"
                    },
                    BusinessName = "Городская клиническая больница №1 г. Белгорода. Поликлиника №1",
                    Licence = new ServiceReference2.Licence()
                    {
                        LicenceNumber = "ЛО-31-01-001270",
                        LicenceStartDate = DateTime.Parse("2019-02-08"),
                        LicenceAdministrator = "Бюджетное учреждение"
                    },
                    Address = new ServiceReference2.AddressType
                    {
                        AddressText = "Белгородская область, г. Белгород, Белгородский проспект, 95а",
                        PostalCode = "308600"
                    },
                    CommunicationNumbers = new ServiceReference2.CommunicationNumbersType
                    {
                        PrimaryTelephone = new ServiceReference2.PhoneType()
                        {
                            Number = "+74722260953"
                        }
                    }
                }
            });
            Console.WriteLine(result.RequestMessage);
            Console.ReadKey();
        }
        static void CancelRxTest()
        {
            ServiceReference2.MedicataMOV2PortClient client = new ServiceReference2.MedicataMOV2PortClient();
            DataService dataService = new DataService();
            client.Endpoint.Behaviors.Add(new SimpleEndpointBehavior());
           

            CancelRxRequest cancelRxRequest = new CancelRxRequest
            {
                PracticeLocation = dataService.GetPracticeLocationType(),//Данные о МО (в т.ч. частнопрактикующего врача), из которой отменяются назначения ЛП/МИ (рецепты)
                PrescribedMedication = dataService.GetPrescribedMedication().ToArray(),//Назначения ЛП/МИ, которые отменяются
                Prescriber = dataService.GetHistoryPrescriber(),//Мед. работник, отменяющий назначение ЛП
                WrittenDate = DateTime.Now,//Дата отмены назначений ЛП/МИ
                SoftwareInformation = new SoftwareInformationType
                {
                    Name = "",
                    Version = "2"
                },
                ChangeReasonText = "Отмена в связи с выдачей дубликата рецепта"

            };

            try
            {
                client.CancelRx(cancelRxRequest);
            }
            catch (FaultException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    public class ProductCode
    {
        public string Code { get; set; }
        public string Qualifier { get; set; }
        public string Text { get; set; }
    }
}

