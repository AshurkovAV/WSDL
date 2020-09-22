using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSDLTest.ServiceReference2;

namespace WSDLTest.Common
{
    public class DataService
    {
        public DataService()
        {
        }

        public PracticeLocationType GetPracticeLocationType()
        {
            var result = new PracticeLocationType();

            try
            {
                result = new PracticeLocationType
                {
                    Identification = new FacilityID
                    {
                        ID = "3220101",
                        MedicareNumber = "3220101",
                        Ogrn = "1024600952353"
                    },
                    BusinessName = "Городская клиническая больница №1 г. Белгорода. Поликлиника №1",
                    Licence = new Licence
                    {
                        LicenceNumber = "ЛО-31-01-002822",
                        LicenceStartDate = DateTime.Parse("2019-03-28"),
                        LicenceEndDate = DateTime.Parse("2099-12-31"),
                        LicenceAdministrator = "ДЕПАРТАМЕНТ ЗДРАВООХРАНЕНИЯ И СОЦИАЛЬНОЙ ЗАЩИТЫ НАСЕЛЕНИЯ БЕЛГОРОДСКОЙ ОБЛАСТИ",
                    },
                    Address = new AddressType
                    {
                        AddressText = "обл. Белгородская,г. Белгород, пр-кт. Белгородский, 95а",
                        
                    },
                    CommunicationNumbers = new CommunicationNumbersType
                    {
                        PrimaryTelephone = new PhoneType
                        {
                            Number = "74722262953"
                        }
                    }
                };
                
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка!");
            }

            return result;
        }

        public HistoryPrescriber GetHistoryPrescriber()
        {
            var result = new HistoryPrescriber();

            try
            {
                result.Identification = new PrescriberID()
                {
                    ID = "1824",
                    Snils = "00000060001"
                };
                result.Name = new NameType()
                {
                    LastName = "Безуглова",
                    FirstName = "Анна",
                    MiddleName = "Николаевна"
                };
                result.Specialty = new ServiceReference2.DictionaryCode()
                {
                    Text = "врач-терапевт участковый",
                    Code = "74"
                };
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка");
            }

            return result;

        }

        public List<RxMedication> GetPrescribedMedication()
        {
            var result = new List<RxMedication>();

            result.Add(new RxMedication
            {
                MedicationIdentification = "8fead3dd-e695-4c10-9808-8db8171f065c",
                RxWrittenDate = DateTime.Parse("2020-01-21"),
                TradeNameFlag = ServiceReference2.BooleanCode.N,
                DrugCoded = new ServiceReference2.DrugCoded
                {
                    Items = new object[]
                            {
                                new DrugProductCodeWithText
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
            });

            return result;
        }

    }
}
