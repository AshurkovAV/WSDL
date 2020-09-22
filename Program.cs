using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WSDLTest.ServiceReference2;

namespace WSDLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Метод предназначен для тестирования работоспособности сервиса МО
            //MOHealthCheks();
            //DrugProductCodeWithText code = new DrugProductCodeWithText();
            //code.Code = "GD000449";
            //code.Qualifier = "GenericDrug";
            //code.Text = "Amoxycillini, капсулы, 500 мг";

            //var medication = new List<RxMedication>();
            //medication.Add(new RxMedication
            //{
            //    DrugCoded = new DrugCoded
            //    {
            //        Items = new object[] { code }
            //    },
            //});
            //medication.ToArray();
            //А в методе CancelRxTest проблема с обращением к DrugCoded
            CancelRxTest();
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
                        LicenceStartDate = DateTime.Parse("20.12.2019"),
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
            var results = client.CancelRx(new ServiceReference2.CancelRxRequest()
            {
                PracticeLocation = new ServiceReference2.PracticeLocationType()
                {
                    Identification = new ServiceReference2.FacilityID()
                    {
                        ID = "3220101",
                        MedicareNumber = "3220101",
                        Ogrn = "3220101"
                    },
                    BusinessName = "Городская клиническая больница №1 г. Белгорода. Поликлиника №1",
                    Licence = new ServiceReference2.Licence()
                    {
                        LicenceNumber = "ЛО-31-01-002822",
                        LicenceStartDate = DateTime.Parse("2019-03-28"),
                        LicenceEndDate = DateTime.Parse("2099-12-31"),
                        LicenceAdministrator = "ДЕПАРТАМЕНТ ЗДРАВООХРАНЕНИЯ И СОЦИАЛЬНОЙ ЗАЩИТЫ НАСЕЛЕНИЯ БЕЛГОРОДСКОЙ ОБЛАСТИ"
                    },
                    Address = new ServiceReference2.AddressType()
                    {
                        AddressText = "обл. Белгородская,г. Белгород, пр-кт. Белгородский, 95а"
                    },
                    CommunicationNumbers = new ServiceReference2.CommunicationNumbersType()
                    {
                        PrimaryTelephone = new ServiceReference2.PhoneType()
                        {
                            Number = "74722262953"
                        }
                    }
                },
                Prescriber = new ServiceReference2.HistoryPrescriber()
                {
                    Identification = new ServiceReference2.PrescriberID()
                    {
                        ID = "1824",
                        Snils = "00000060001"
                    },
                    Name = new ServiceReference2.NameType()
                    {
                        LastName = "Безуглова",
                        FirstName = "Анна",
                        MiddleName = "Николаевна"
                    },
                    Specialty = new ServiceReference2.DictionaryCode()
                    {
                        Text = "врач-терапевт участковый",
                        Code = "74"
                    }
                },
                PrescribedMedication = new ServiceReference2.RxMedication[]
                {
                    new ServiceReference2.RxMedication()
                    {
                        MedicationIdentification = "8fead3dd-e695-4c10-9808-8db8171f065c",
                        RxWrittenDate = DateTime.Parse("2020-01-21"),
                        TradeNameFlag = ServiceReference2.BooleanCode.N,
                        DrugCoded = new ServiceReference2.DrugCoded()
                        {
                            Items = new object[]
                            {
                                new DrugProductCodeWithText()
                                {
                                    Code ="GD000449",
                                    Qualifier = AllergyDrugProductCodedQualifier.GenericDrug,
                                    Text = "Amoxycillini, капсулы, 500 мг"
                                }
                            }
                        },
                        Sig = new Sig()
                        {
                            SigText = "Принимать, 500 мг, перорально, 2 раза в день, в течение 10 дней"
                        },
                        ChronicDiseaseFlag = ServiceReference2.BooleanCode.Y,
                        RxPrescriptions = new ServiceReference2.AdministrativeRxExtBarcode[]
                        {
                            new ServiceReference2.AdministrativeRxExtBarcode()
                            {
                                RxPrescriptionIdentification = "a9132ed0-909b-4dfb-83a0-61a3ce65deb5",
                                RxType = ServiceReference2.RxTypes.rx1071u,
                                RxNumber = "9427045",
                                RxWrittenDate = DateTime.Parse("2020-01-21"),
                                DaysSupply = "60",
                                MedicalOrganization = new PracticeLocationType()
                                {
                                    Identification = new FacilityID()
                                    {
                                        ID = "3220101",
                                        MedicareNumber = "3220101",
                                        Ogrn = "1023101681745"
                                    },
                                    BusinessName = "Городская клиническая больница №1 г. Белгорода. Поликлиника №1",
                                    Licence = new Licence()
                                    {
                                        LicenceNumber = "ЛО-31-01-002822",
                                        LicenceStartDate = DateTime.Parse("2019-03-28"),
                                        LicenceEndDate = DateTime.Parse("2099-12-31"),
                                        LicenceAdministrator = "ДЕПАРТАМЕНТ ЗДРАВООХРАНЕНИЯ И СОЦИАЛЬНОЙ ЗАЩИТЫ НАСЕЛЕНИЯ БЕЛГОРОДСКОЙ ОБЛАСТИ"
                                    },
                                    Address = new AddressType()
                                    {
                                        AddressText = "обл. Белгородская,г. Белгород, пр-кт. Белгородский, 95а"
                                    },
                                    CommunicationNumbers = new CommunicationNumbersType()
                                    {
                                        PrimaryTelephone = new PhoneType()
                                        {
                                            Number = "74722262953"
                                        }
                                    }
                                },
                                Prescriber = new AdministrativeRxPrescriber()
                                {
                                    Identification = new PrescriberID()
                                    {
                                        ID = "1824",
                                        Snils = "00000060001"
                                    },
                                    Name = new NameType()
                                    {
                                        LastName = "Безуглова",
                                        FirstName = "Анна",
                                        MiddleName = "Николаевна"
                                    },
                                    Specialty = new DictionaryCode()
                                    {
                                        Text = "врач-терапевт участковый",
                                        Code = "74"
                                    }
                                },
                                Patient = new RxPatientType()
                                {
                                    Name = new NameType()
                                    {
                                        FirstName = "Пётрова",
                                        LastName = "Ирина",
                                        MiddleName = "Николаёвна"
                                    },
                                    Identification = new PatientIDForMO()
                                    {
                                        Snils = "00000060002",
                                        MedicareNumber = "125334233",
                                        MedicalNumber = "2615321"
                                    },
                                    Address = new AddressType()
                                    {
                                        AddressText = "Белгородская обл., Белгород г. Газовиков ул 12 кв. 43"
                                    },
                                    CommunicationNumbers = new CommunicationNumbersType()
                                    {
                                        PrimaryTelephone = new PhoneType()
                                        {
                                            Number = "79488451412"
                                        }
                                    },
                                    ChildFlag = BooleanCode.N,
                                    AgeYears = "51"
                                },
                                Diagnosis = new Diagnosis()
                                {
                                    Primary = new DictionaryCode()
                                    {
                                        Text = "Острый тонзиллит неуточненный",
                                        Code = "J03.9"
                                    }
                                },
                                Rp = new RpType()
                                {
                                    MedicationFreeText = "Amoxycillini, капсулы",
                                    Dosing = "500 мг",
                                    MedicationQuantity = "20",
                                    SignaFreeText = "Принимать, 500 мг, перорально, 2 раза в день, в течение 10 дней"
                                },
                                PriorAuthorization = PriorAuthorizationType.cito,
                                BaseDoseOverride = BooleanCode.N,
                                SpecialPurpose = BooleanCode.N,
                                ChronicDiseaseFlag = BooleanCode.N

                            }

                        }
                    }
                }

            });
            
        }
    }

    //public class DrugProductCodeWithText
    //{ 
    //    public string Code { get; set; }
    //    public string Qualifier { get; set; }
    //    public string Text { get; set; }
    //}
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://medicata.ru/schemas/v2/medicata")]
    public partial class DrugProductCodeWithText : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string codeField;

        private AllergyDrugProductCodedQualifier qualifierField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public AllergyDrugProductCodedQualifier Qualifier
        {
            get
            {
                return this.qualifierField;
            }
            set
            {
                this.qualifierField = value;
                this.RaisePropertyChanged("Qualifier");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
                this.RaisePropertyChanged("Text");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://medicata.ru/schemas/v2/medicata")]
    public partial class DrugCoded : object, System.ComponentModel.INotifyPropertyChanged
    {

        private object[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CompositeProductCode", typeof(DrugProductCodeWithDoseText), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("IndividualManufactured", typeof(BooleanCode), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ProductClarifyingFreeText", typeof(string), Order = 0)]
        [System.Xml.Serialization.XmlElementAttribute("ProductCode", typeof(DrugProductCodeWithText), Order = 0)]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
                this.RaisePropertyChanged("Items");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

