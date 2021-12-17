using Core.Entities.District;
using Core.Services.Rest;
using Core.Services.Rest.GoogleMap;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Rest.GoogleMap
{
    public class LocationService : ILocationService
    {
        private IRestClient _client;
        private RestRequest _request;
        private string _url;

        public LocationService()
        {
            _request = new RestRequest(Method.POST);
            _url = "https://maps.googleapis.com/maps/api/geocode/json?address={ADDRESS}&key=AIzaSyBRgqgdAaGwBf98BI1fw0mUZ2NGnBUnytI";
        }

        public async Task<List<District>> GetAllDistrictsWithSubsAsync()
        {
            var districts = new List<District>();

            foreach (var address in Addresses)
            {
                _client = new RestClient(GetBaseUrl(address.Name_AZ));

                var response = await _client.ExecuteAsync(_request);
                var serializedResponse = JsonConvert.DeserializeObject<Response>(response.Content.ToString());

                var district = new District
                {
                    Name_AZ = address.Name_AZ,
                    Name_RU = address.Name_RU,
                    Name_EN = address.Name_EN,
                    X = serializedResponse.Results[0].Geometry.Location.Lng,
                    Y = serializedResponse.Results[0].Geometry.Location.Lat,
                };

                foreach (var subAdress in address.SubAdresses)
                {
                    _client = new RestClient(GetBaseUrl(subAdress.Name_AZ));

                    response = await _client.ExecuteAsync(_request);
                    serializedResponse = JsonConvert.DeserializeObject<Response>(response.Content.ToString());

                    var subDistrict = new SubDistrict
                    {
                        Name_AZ = subAdress.Name_AZ,
                        Name_RU = subAdress.Name_RU,
                        Name_EN = subAdress.Name_EN,
                        X = serializedResponse.Results[0].Geometry.Location.Lng,
                        Y = serializedResponse.Results[0].Geometry.Location.Lat,
                    };

                    district.SubDistricts.Add(subDistrict);
                }

                districts.Add(district);
            }

            return districts;
        }

        private string GetBaseUrl(string address)
        {
            return _url.Replace("{ADDRESS}", address);
        }

        #region Addresses

        private static List<Address> Addresses = new List<Address>
        {
            new Address
            { Name_AZ = "Abşeron", Name_RU = "Апшерон", Name_EN = "Absheron", SubAdresses = new List<SubAdress>
                  {
                     new SubAdress { Name_AZ = "Ceyranbatan", Name_RU = "Джейранбатан", Name_EN = "Jeyranbatan" },
                     new SubAdress { Name_AZ = "Çiçək", Name_RU = "Чичек", Name_EN = "Chicek" },
                     new SubAdress { Name_AZ = "Digah", Name_RU = "Дигях", Name_EN = "Digah" },
                     new SubAdress { Name_AZ = "Fatmayı", Name_RU = "Фатмайы", Name_EN = "Fatmayi" },
                     new SubAdress { Name_AZ = "Görədil", Name_RU = "Горадил", Name_EN = "Goradil" },
                     new SubAdress { Name_AZ = "Hökməli", Name_RU = "Геокмалы", Name_EN = "Geokmaly"},
                     new SubAdress { Name_AZ = "Corat", Name_RU = "Джорат", Name_EN = "Jorat" },
                     new SubAdress { Name_AZ = "Qobu", Name_RU = "Кобу", Name_EN = "Qobu" },
                     new SubAdress { Name_AZ = "Masazır", Name_RU = "Масазыр", Name_EN = "Masazir" },
                     new SubAdress { Name_AZ = "Mehdiabad", Name_RU = "Мехтиабад", Name_EN = "Mehtiabad"},
                     new SubAdress { Name_AZ = "Müşviqabad", Name_RU = "Мушфигабад", Name_EN = "Mushviqabad"},
                     new SubAdress { Name_AZ = "Novxanı", Name_RU = "Новханы", Name_EN = "Novxani"},
                     new SubAdress { Name_AZ = "Saray", Name_RU = "Сарай", Name_EN = "Saray"},
                     new SubAdress { Name_AZ = "Zağulba", Name_RU = "Загульба", Name_EN = "Zagulba" },
                  },
            },

            new Address
            { Name_AZ = "Binəqədi", Name_RU = "Бинагади", Name_EN = "Binagadi", SubAdresses = new List<SubAdress>
                  {
                     //new SubAdress { Name_AZ = "2-ci Alatava", Name_RU = "2-ая Алатава", Name_EN = "2-nd Alatava" }
                     new SubAdress { Name_AZ = "28 May", Name_RU = "28 мая", Name_EN = "28 May" },
                     new SubAdress { Name_AZ = "6-cı mkr", Name_RU = "6-ой мкр", Name_EN = "6-th mkr" },
                     new SubAdress { Name_AZ = "7-ci mkr", Name_RU = "7-ой мкр", Name_EN = "7-th mkr" },
                     new SubAdress { Name_AZ = "8-ci mkr", Name_RU = "8-й мкр", Name_EN = "8-th mkr" },
                     new SubAdress { Name_AZ = "9-cu mkr", Name_RU = "9-й мкр", Name_EN = "9-th mkr" },
                     new SubAdress { Name_AZ = "Biləcəri", Name_RU = "Биладжары", Name_EN = "Bilajari" },
                     new SubAdress { Name_AZ = "Binəqədi", Name_RU = "Бинагади", Name_EN = "Binagadi" },
                     new SubAdress { Name_AZ = "Xocəsən", Name_RU = "Ходжасан", Name_EN = "Khojasan" },
                     new SubAdress { Name_AZ = "Xutor", Name_RU = "Хутор", Name_EN = "Khutor" },
                     new SubAdress { Name_AZ = "Sulutəpə", Name_RU = "Сулутепе", Name_EN = "Sulutepe" }
                  },
            },

            new Address
            { Name_AZ = "Xətai", Name_RU = "Хатаи", Name_EN = "Xatai", SubAdresses = new List<SubAdress>
                  {
                     new SubAdress { Name_AZ = "Əhmədli", Name_RU = "Ахмадли", Name_EN = "Ahmadli" },
                     new SubAdress { Name_AZ = "Həzi Aslanov", Name_RU = "Ази Асланов", Name_EN = "Hazi Aslanov" },
                     new SubAdress { Name_AZ = "Köhnə Günəşli", Name_RU = "Гюнешли", Name_EN = "Gunashli"}
                  }
            },

            new Address
            { Name_AZ = "Xəzər", Name_RU = "Хазар", Name_EN = "Khazar", SubAdresses = new List<SubAdress>
                  {
                     new SubAdress { Name_AZ = "Binə", Name_RU = "Бина", Name_EN = "Bine" },
                     new SubAdress { Name_AZ = "Buzovna", Name_RU = "Бузовна", Name_EN = "Buzovna" },
                     new SubAdress { Name_AZ = "Dübəndi", Name_RU = "Дюбенди", Name_EN = "Dubandi" },
                     new SubAdress { Name_AZ = "Gürgən", Name_RU = "Гюргян", Name_EN = "Gurgan" },
                     new SubAdress { Name_AZ = "Qala", Name_RU = "Гала", Name_EN = "Khala" },
                     new SubAdress { Name_AZ = "Mərdəkan", Name_RU = "Мардакан", Name_EN = "Mardakan" },
                     new SubAdress { Name_AZ = "Şağan", Name_RU = "Шаган", Name_EN = "Shagan" } ,
                     new SubAdress { Name_AZ = "Şimal DRES", Name_RU = "Северный Грэс", Name_EN = "North Grace" } ,
                     new SubAdress { Name_AZ = "Şüvəlan", Name_RU = "Шувелан", Name_EN = "Shuvalan" } ,
                     new SubAdress { Name_AZ = "Türkan", Name_RU = "Тюркан", Name_EN = "Turkan" } ,
                     new SubAdress { Name_AZ = "Zirə", Name_RU = "Зире", Name_EN = "Zire" } ,
                  }
            },

            new Address
            { Name_AZ = "Qaradağ", Name_RU = "Гарадаг", Name_EN = "Karadagh", SubAdresses = new List<SubAdress>
                  {
                     new SubAdress { Name_AZ = "Bibi Heybət", Name_RU = "Биби-Эйбат", Name_EN = "Bibi Heybet" },
                     new SubAdress { Name_AZ = "Ələt", Name_RU = "Аляты", Name_EN = "Elet" },
                     new SubAdress { Name_AZ = "Qızıldaş", Name_RU = "Кызылдаш", Name_EN = "Khızıldash" },
                     new SubAdress { Name_AZ = "Qobustan", Name_RU = "Гобустан", Name_EN = "Khobustan" },
                     new SubAdress { Name_AZ = "Lökbatan", Name_RU = "Локбатан", Name_EN = "Lokbatan"},
                     new SubAdress { Name_AZ = "Puta", Name_RU = "Пута", Name_EN = "Puta"},
                     new SubAdress { Name_AZ = "Sahil", Name_RU = "Сахиль", Name_EN = "Sahil"},
                     new SubAdress { Name_AZ = "Səngəçal", Name_RU = "Сангачал", Name_EN = "Sangachal"},
                     new SubAdress { Name_AZ = "Şıxov", Name_RU = "Шихов", Name_EN = "Shikhov"},
                     new SubAdress { Name_AZ = "Şubani", Name_RU = "Шубаны", Name_EN = "Shubani"},
                  }
            },
        };

        #endregion
    }

    public class Address
    {
        public string Name_AZ { get; set; }

        public string Name_RU { get; set; }

        public string Name_EN { get; set; }

        public Address()
        {
            SubAdresses = new List<SubAdress>();
        }

        public List<SubAdress> SubAdresses { get; set; }
    }

    public class SubAdress
    {
        public string Name_AZ { get; set; }

        public string Name_RU { get; set; }

        public string Name_EN { get; set; }
    }

    #region Serializers 

    public class Response
    {
        public Result[] Results { get; set; }
    }

    public class Result
    {
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    #endregion
}
