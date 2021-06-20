using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Models
{
    public class Geo
    {
        public class Region
        {
            public string nom { get; set; }
            public ICollection<Departement> departements { get; set; }
            public int btqCount 
            { get 
                { return departements.Sum(d => d.btqCount); } 
            }
            public int prodCount
            {
                get
                { return departements.Sum(d => d.prodCount); }
            }
        }
        public class Departement
        {
            public string nom { get; set; }
            public string num { get; set; }
            public int btqCount { get; set; }
            public int prodCount { get; set; }
        }
        public List<Region> Regions = new List<Region>
        {
            new Region
            {
                nom = "Alsace",
                departements = new List<Departement>
                { new Departement
                { nom ="Bas-Rhin",
                  num = "67"
                },
                new Departement
                { nom ="Haut-Rhin",
                  num = "68"
                }
                }
            },
            new Region
            {
                nom = "Aquitaine",
                departements = new List<Departement>
                { new Departement
                { nom ="Dordogne",
                  num = "24"
                },
                    new Departement
                { nom ="Gironde",
                  num = "33"
                },
                    new Departement
                { nom ="Landes",
                  num = "40"
                },
                    new Departement
                { nom ="Lot-et-Garonne",
                  num = "47"
                },
                    new Departement
                { nom ="Pyrénées-Atlantiques",
                  num = "64"
                }
                }
            },
            new Region
            {
                nom = "Auvergne",
                departements = new List<Departement>
                { new Departement
                { nom ="Allier",
                  num = "03"
                },
                     new Departement
                { nom ="Cantal",
                  num = "15"
                },
                      new Departement
                { nom ="Haute-Loire",
                  num = "43"
                },
                       new Departement
                { nom ="Puy-de-Dôme",
                  num = "63"
                }
                }
            },
            new Region
            {
                nom = "Basse-Normandie",
                departements = new List<Departement>
                { new Departement
                { nom ="Calvados",
                  num = "14"
                },
                     new Departement
                { nom ="Manche",
                  num = "50"
                },
                      new Departement
                { nom ="Orne",
                  num = "61"
                }
                }
            },
            new Region
            {
                nom = "Bourgogne",
                departements = new List<Departement>
                { new Departement
                { nom ="Côte-d'Or",
                  num = "21"
                },
                    new Departement
                { nom ="Nièvre",
                  num = "58"
                },
                    new Departement
                { nom ="Saône-et-Loire",
                  num = "71"
                },
                    new Departement
                { nom ="Yonne",
                  num = "89"
                }
                }
            },
            new Region
            {
                nom = "Bretagne",
                departements = new List<Departement>
                { new Departement
                { nom ="Côtes-d'Armor",
                  num = "22"
                },
                     new Departement
                { nom ="Finistère",
                  num = "29"
                },
                      new Departement
                { nom ="Ille-et-Vilaine",
                  num = "35"
                },
                       new Departement
                { nom ="Morbihan",
                  num = "56"
                }
                }
            },
            new Region
            {
                nom = "Centre",
                departements = new List<Departement>
                { new Departement
                { nom ="Cher",
                  num = "18"
                },
                     new Departement
                { nom ="Eure-et-Loir",
                  num = "28"
                },
                      new Departement
                { nom ="Indre",
                  num = "36"
                },
                       new Departement
                { nom ="Indre-et-Loire",
                  num = "37"
                },
                        new Departement
                { nom ="Loir-et-Cher",
                  num = "41"
                },
                         new Departement
                { nom ="Loiret",
                  num = "45"
                }
                }
            },
            new Region
            {
                nom = "Champagne-Ardenne",
                departements = new List<Departement>
                { new Departement
                { nom ="Ardennes",
                  num = "08"
                },
                    new Departement
                { nom ="Aube",
                  num = "10"
                },
                    new Departement
                { nom ="Marne",
                  num = "51"
                },
                    new Departement
                { nom ="Haute-Marne",
                  num = "52"
                }
                }
            },
            new Region
            {
                nom = "Corse",
                departements = new List<Departement>
                { new Departement
                { nom ="Corse-du-Sud",
                  num = "2A"
                },
                    new Departement
                { nom ="Haute-Corse",
                  num = "2B"
                }
                }
            },
            new Region
            {
                nom = "Franche-Comté",
                departements = new List<Departement>
                { new Departement
                { nom ="Doubs ",
                  num = "25"
                },
                    new Departement
                { nom ="Jura ",
                  num = "39"
                },
                    new Departement
                { nom ="Haute-Saône",
                  num = "70"
                },
                    new Departement
                { nom ="Territoire de Belfort",
                  num = "90"
                }
                }
            },
            //new Region
            //{
            //    nom = "Guadeloupe",
            //    departements = new List<Departement>
            //    { new Departement
            //    { nom ="Guadeloupe",
            //      num = "971"
            //    }
            //    }
            //},
            //new Region
            //{
            //    nom = "Guyane",
            //    departements = new List<Departement>
            //    { new Departement
            //    { nom ="Guyane",
            //      num = "973"
            //    }
            //    }
            //},
            new Region
            {
                nom = "Haute-Normandie",
                departements = new List<Departement>
                { new Departement
                { nom ="Seine-Maritime",
                  num = "76"
                },
                    new Departement
                { nom ="Eure",
                  num = "27"
                }
                }
            },
            new Region
            {
                nom = "Île-de-France",
                departements = new List<Departement>
                { new Departement
                { nom ="Paris",
                  num = "75"
                },
                    new Departement
                { nom ="Seine-et-Marne",
                  num = "77"
                },
                    new Departement
                { nom ="Yvelines",
                  num = "78"
                },
                    new Departement
                { nom ="Essonne",
                  num = "91"
                },
                    new Departement
                { nom ="Hauts-de-Seine",
                  num = "92"
                },
                    new Departement
                { nom ="Seine-Saint-Denis",
                  num = "93"
                },
                    new Departement
                { nom ="Val-de-Marne",
                  num = "94"
                },
                    new Departement
                { nom ="Val-d'Oise",
                  num = "95"
                }
                }
            },
            //new Region
            //{
            //    nom = "La Réunion",
            //    departements = new List<Departement>
            //    { new Departement
            //    { nom ="La Réunion",
            //      num = "974"
            //    }
            //    }
            //},
            new Region
            {
                nom = "Languedoc-Roussillon",
                departements = new List<Departement>
                { new Departement
                { nom ="Aude",
                  num = "11"
                },
                    new Departement
                { nom ="Gard",
                  num = "30"
                },
                    new Departement
                { nom ="Hérault",
                  num = "34"
                },
                    new Departement
                { nom ="Lozère",
                  num = "48"
                },
                    new Departement
                { nom ="Pyrénées-Orientales",
                  num = "66"
                }
                }
            },
            new Region
            {
                nom = "Limousin",
                departements = new List<Departement>
                { new Departement
                { nom = "Corrèze",
                  num = "19"
                },
                    new Departement
                { nom = "Creuse",
                  num = "23"
                },
                    new Departement
                { nom = "Haute-Vienne",
                  num = "87"
                }
                }
            },
            new Region
            {
                nom = "Lorraine",
                departements = new List<Departement>
                { new Departement
                { nom ="Meurthe-et-Moselle",
                  num = "54"
                },
                    new Departement
                { nom ="Meuse",
                  num = "55"
                },
                    new Departement
                { nom ="Moselle",
                  num = "57"
                },
                    new Departement
                { nom ="Vosges",
                  num = "88"
                }
                }
            },
            //new Region
            //{
            //    nom = "Martinique",
            //    departements = new List<Departement>
            //    { new Departement
            //    { nom ="Martinique",
            //      num = "972"
            //    }
            //    }
            //},
            //new Region
            //{
            //    nom = "Mayotte",
            //    departements = new List<Departement>
            //    { new Departement
            //    { nom ="Mayotte",
            //      num = "976"
            //    }
            //    }
            //},
            new Region
            {
                nom = "Midi-Pyrénées",
                departements = new List<Departement>
                { new Departement
                { nom ="Ariège",
                  num = "09"
                },
                    new Departement
                { nom ="Aveyron",
                  num = "12"
                },
                    new Departement
                { nom ="Haute-Garonne",
                  num = "31"
                },
                    new Departement
                { nom ="Gers",
                  num = "32"
                },
                    new Departement
                { nom ="Lot",
                  num = "46"
                },
                    new Departement
                { nom ="Hautes-Pyrénées",
                  num = "65"
                },
                    new Departement
                { nom ="Tarn",
                  num = "81"
                },
                    new Departement
                { nom ="Tarn-et-Garonne",
                  num = "82"
                }
                }
            },
            new Region
            {
                nom = "Nord-Pas-de-Calais",
                departements = new List<Departement>
                { new Departement
                { nom ="Nord",
                  num = "59"
                },
                    new Departement
                { nom ="Pas-de-Calais",
                  num = "62"
                }
                }
            },
            new Region
            {
                nom = "Pays de la Loire",
                departements = new List<Departement>
                { new Departement
                { nom ="Loire-Atlantique",
                  num = "44"
                },
                    new Departement
                { nom ="Maine-et-Loire",
                  num = "49"
                },
                    new Departement
                { nom ="Mayenne",
                  num = "53"
                },
                    new Departement
                { nom ="Sarthe",
                  num = "72"
                },
                    new Departement
                { nom ="Vendée",
                  num = "85"
                }
                }
            },
            new Region
            {
                nom = "Picardie",
                departements = new List<Departement>
                { new Departement
                { nom ="Aisne",
                  num = "02"
                },
                    new Departement
                { nom ="Oise",
                  num = "60"
                },
                    new Departement
                { nom ="Somme",
                  num = "80"
                }
                }
            },
            new Region
            {
                nom = "Poitou-Charentes",
                departements = new List<Departement>
                { new Departement
                { nom ="Charente",
                  num = "16"
                },
                    new Departement
                { nom ="Charente-Maritime",
                  num = "17"
                },
                    new Departement
                { nom ="Deux-Sèvres",
                  num = "79"
                },
                    new Departement
                { nom ="Vienne",
                  num = "86"
                }
                }
            },
            new Region
            {
                nom = "Provence-Alpes-Côte d'Azur",
                departements = new List<Departement>
                { new Departement
                { nom ="Alpes-de-Haute-Provence",
                  num = "04"
                },
                    new Departement
                { nom ="Hautes-Alpes",
                  num = "05"
                },
                    new Departement
                { nom ="Alpes-Maritimes",
                  num = "06"
                },
                    new Departement
                { nom ="Bouches-du-Rhône",
                  num = "13"
                },
                    new Departement
                { nom ="Var",
                  num = "83"
                },
                    new Departement
                { nom ="Vaucluse",
                  num = "84"
                }
                }
            },
            new Region
            {
                nom = "Rhône-Alpes",
                departements = new List<Departement>
                { new Departement
                { nom ="Ardèche",
                  num = "07"
                },
                    new Departement
                { nom ="Drôme",
                  num = "26"
                },
                    new Departement
                { nom ="Isère",
                  num = "38"
                },
                    new Departement
                { nom ="Loire",
                  num = "42"
                },
                    new Departement
                { nom ="Rhône",
                  num = "69"
                },
                    new Departement
                { nom ="Savoie",
                  num = "73"
                },
                    new Departement
                { nom ="Haute-Savoie",
                  num = "74"
                }
                }
            },


        };
    }

}
