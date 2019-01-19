using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
 * Imports all elements in a static class
 */

public static class AllElements{

    static List<Element> MendeljevElementen;

    static AllElements() {
        MendeljevElementen = new List<Element>();
        setElementenHard();
    }

    static void setElementen()
    {
        string hardCoded="";
        using (var reader = new StreamReader(@".\Assets\Resources\data.csv"))
        {
            //Eerste lijn met benamingen skippen
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                hardCoded=hardCoded+'\n'+"MendeljevElementen.Add(new Element(" +'\"' +values[0] + '\"' + ',' + '\"' + values[1] + '\"' + ',' + '\"' + values[2] + '\"' + ',' + '\"' + values[3] + '\"' + ',' + '\"' 
                    + values[4] + '\"' + ',' + '\"' + values[9] +'\"'+",\"" + values[7] + "\"));";
                Element element = new Element(values[0],values[1],values[2],values[3],values[4],values[9],values[7]);
                MendeljevElementen.Add(element);
            }
        }
        Debug.Log(hardCoded);
    }

    static void setElementenHard() {
        MendeljevElementen.Add(new Element("1", " H ", " Hydrogen", " 1.00794(4)", "FFFFFF", "120", "37"));
        MendeljevElementen.Add(new Element("2", " He ", " Helium", " 4.002602(2)", "D9FFFF", "140", "32"));
        MendeljevElementen.Add(new Element("3", " Li ", " Lithium", " 6.941(2)", "CC80FF", "182", "134"));
        MendeljevElementen.Add(new Element("4", " Be ", " Beryllium", " 9.012182(3)", "C2FF00", "", "90"));
        MendeljevElementen.Add(new Element("5", " B ", " Boron", " 10.811(7)", "FFB5B5", "", "82"));
        MendeljevElementen.Add(new Element("6", " C ", " Carbon", " 12.0107(8)", "909090", "170", "77"));
        MendeljevElementen.Add(new Element("7", " N ", " Nitrogen", " 14.0067(2)", "3050F8", "155", "75"));
        MendeljevElementen.Add(new Element("8", " O ", " Oxygen", " 15.9994(3)", "FF0D0D", "152", "73"));
        MendeljevElementen.Add(new Element("9", " F ", " Fluorine", " 18.9984032(5)", "90E050", "147", "71"));
        MendeljevElementen.Add(new Element("10", " Ne ", " Neon", " 20.1797(6)", "B3E3F5", "154", "69"));
        MendeljevElementen.Add(new Element("11", " Na ", " Sodium", " 22.98976928(2)", "AB5CF2", "227", "154"));
        MendeljevElementen.Add(new Element("12", " Mg ", " Magnesium", " 24.3050(6)", "8AFF00", "173", "130"));
        MendeljevElementen.Add(new Element("13", " Al ", " Aluminum", " 26.9815386(8)", "BFA6A6", "", "118"));
        MendeljevElementen.Add(new Element("14", " Si ", " Silicon", " 28.0855(3)", "F0C8A0", "210", "111"));
        MendeljevElementen.Add(new Element("15", " P ", " Phosphorus", " 30.973762(2)", "FF8000", "180", "106"));
        MendeljevElementen.Add(new Element("16", " S ", " Sulfur", " 32.065(5)", "FFFF30", "180", "102"));
        MendeljevElementen.Add(new Element("17", " Cl ", " Chlorine", " 35.453(2)", "1FF01F", "175", "99"));
        MendeljevElementen.Add(new Element("18", " Ar ", " Argon", " 39.948(1)", "80D1E3", "188", "97"));
        MendeljevElementen.Add(new Element("19", " K ", " Potassium", " 39.0983(1)", "8F40D4", "275", "196"));
        MendeljevElementen.Add(new Element("20", " Ca ", " Calcium", " 40.078(4)", "3DFF00", "", "174"));
        MendeljevElementen.Add(new Element("21", " Sc ", " Scandium", " 44.955912(6)", "E6E6E6", "", "144"));
        MendeljevElementen.Add(new Element("22", " Ti ", " Titanium", " 47.867(1)", "BFC2C7", "", "136"));
        MendeljevElementen.Add(new Element("23", " V ", " Vanadium", " 50.9415(1)", "A6A6AB", "", "125"));
        MendeljevElementen.Add(new Element("24", " Cr ", " Chromium", " 51.9961(6)", "8A99C7", "", "127"));
        MendeljevElementen.Add(new Element("25", " Mn ", " Manganese", " 54.938045(5)", "9C7AC7", "", "139"));
        MendeljevElementen.Add(new Element("26", " Fe ", " Iron", " 55.845(2)", "E06633", "", "125"));
        MendeljevElementen.Add(new Element("27", " Co ", " Cobalt", " 58.933195(5)", "F090A0", "", "126"));
        MendeljevElementen.Add(new Element("28", " Ni ", " Nickel", " 58.6934(4)", "50D050", "163", "121"));
        MendeljevElementen.Add(new Element("29", " Cu ", " Copper", " 63.546(3)", "C88033", "140", "138"));
        MendeljevElementen.Add(new Element("30", " Zn ", " Zinc", " 65.38(2)", "7D80B0", "139", "131"));
        MendeljevElementen.Add(new Element("31", " Ga ", " Gallium", " 69.723(1)", "C28F8F", "187", "126"));
        MendeljevElementen.Add(new Element("32", " Ge ", " Germanium", " 72.64(1)", "668F8F", "", "122"));
        MendeljevElementen.Add(new Element("33", " As ", " Arsenic", " 74.92160(2)", "BD80E3", "185", "119"));
        MendeljevElementen.Add(new Element("34", " Se ", " Selenium", " 78.96(3)", "FFA100", "190", "116"));
        MendeljevElementen.Add(new Element("35", " Br ", " Bromine", " 79.904(1)", "A62929", "185", "114"));
        MendeljevElementen.Add(new Element("36", " Kr ", " Krypton", " 83.798(2)", "5CB8D1", "202", "110"));
        MendeljevElementen.Add(new Element("37", " Rb ", " Rubidium", " 85.4678(3)", "702EB0", "", "211"));
        MendeljevElementen.Add(new Element("38", " Sr ", " Strontium", " 87.62(1)", "00FF00", "", "192"));
        MendeljevElementen.Add(new Element("39", " Y ", " Yttrium", " 88.90585(2)", "94FFFF", "", "162"));
        MendeljevElementen.Add(new Element("40", " Zr ", " Zirconium", " 91.224(2)", "94E0E0", "", "148"));
        MendeljevElementen.Add(new Element("41", " Nb ", " Niobium", " 92.90638(2)", "73C2C9", "", "137"));
        MendeljevElementen.Add(new Element("42", " Mo ", " Molybdenum", " 95.96(2)", "54B5B5", "", "145"));
        MendeljevElementen.Add(new Element("43", " Tc ", " Technetium", " [98]", "3B9E9E", "", "156"));
        MendeljevElementen.Add(new Element("44", " Ru ", " Ruthenium", " 101.07(2)", "248F8F", "", "126"));
        MendeljevElementen.Add(new Element("45", " Rh ", " Rhodium", " 102.90550(2)", "0A7D8C", "", "135"));
        MendeljevElementen.Add(new Element("46", " Pd ", " Palladium", " 106.42(1)", "006985", "163", "131"));
        MendeljevElementen.Add(new Element("47", " Ag ", " Silver", " 107.8682(2)", "C0C0C0", "172", "153"));
        MendeljevElementen.Add(new Element("48", " Cd ", " Cadmium", " 112.411(8)", "FFD98F", "158", "148"));
        MendeljevElementen.Add(new Element("49", " In ", " Indium", " 114.818(3)", "A67573", "193", "144"));
        MendeljevElementen.Add(new Element("50", " Sn ", " Tin", " 118.710(7)", "668080", "217", "141"));
        MendeljevElementen.Add(new Element("51", " Sb ", " Antimony", " 121.760(1)", "9E63B5", "", "138"));
        MendeljevElementen.Add(new Element("52", " Te ", " Tellurium", " 127.60(3)", "D47A00", "206", "135"));
        MendeljevElementen.Add(new Element("53", " I ", " Iodine", " 126.90447(3)", "940094", "198", "133"));
        MendeljevElementen.Add(new Element("54", " Xe ", " Xenon", " 131.293(6)", "429EB0", "216", "130"));
        MendeljevElementen.Add(new Element("55", " Cs ", " Cesium", " 132.9054519(2)", "57178F", "", "225"));
        MendeljevElementen.Add(new Element("56", " Ba ", " Barium", " 137.327(7)", "00C900", "", "198"));
        MendeljevElementen.Add(new Element("57", " La ", " Lanthanum", " 138.90547(7)", "70D4FF", "", "169"));
        MendeljevElementen.Add(new Element("58", " Ce ", " Cerium", " 140.116(1)", "FFFFC7", "", ""));
        MendeljevElementen.Add(new Element("59", " Pr ", " Praseodymium", " 140.90765(2)", "D9FFC7", "", ""));
        MendeljevElementen.Add(new Element("60", " Nd ", " Neodymium", " 144.242(3)", "C7FFC7", "", ""));
        MendeljevElementen.Add(new Element("61", " Pm ", " Promethium", " [145]", "A3FFC7", "", ""));
        MendeljevElementen.Add(new Element("62", " Sm ", " Samarium", " 150.36(2)", "8FFFC7", "", ""));
        MendeljevElementen.Add(new Element("63", " Eu ", " Europium", " 151.964(1)", "61FFC7", "", ""));
        MendeljevElementen.Add(new Element("64", " Gd ", " Gadolinium", " 157.25(3)", "45FFC7", "", ""));
        MendeljevElementen.Add(new Element("65", " Tb ", " Terbium", " 158.92535(2)", "30FFC7", "", ""));
        MendeljevElementen.Add(new Element("66", " Dy ", " Dysprosium", " 162.500(1)", "1FFFC7", "", ""));
        MendeljevElementen.Add(new Element("67", " Ho ", " Holmium", " 164.93032(2)", "00FF9C", "", ""));
        MendeljevElementen.Add(new Element("68", " Er ", " Erbium", " 167.259(3)", "FFFFFF", "", ""));
        MendeljevElementen.Add(new Element("69", " Tm ", " Thulium", " 168.93421(2)", "00D452", "", ""));
        MendeljevElementen.Add(new Element("70", " Yb ", " Ytterbium", " 173.054(5)", "00BF38", "", ""));
        MendeljevElementen.Add(new Element("71", " Lu ", " Lutetium", " 174.9668(1)", "00AB24", "", "160"));
        MendeljevElementen.Add(new Element("72", " Hf ", " Hafnium", " 178.49(2)", "4DC2FF", "", "150"));
        MendeljevElementen.Add(new Element("73", " Ta ", " Tantalum", " 180.94788(2)", "4DA6FF", "", "138"));
        MendeljevElementen.Add(new Element("74", " W ", " Tungsten", " 183.84(1)", "2194D6", "", "146"));
        MendeljevElementen.Add(new Element("75", " Re ", " Rhenium", " 186.207(1)", "267DAB", "", "159"));
        MendeljevElementen.Add(new Element("76", " Os ", " Osmium", " 190.23(3)", "266696", "", "128"));
        MendeljevElementen.Add(new Element("77", " Ir ", " Iridium", " 192.217(3)", "175487", "", "137"));
        MendeljevElementen.Add(new Element("78", " Pt ", " Platinum", " 195.084(9)", "D0D0E0", "175", "128"));
        MendeljevElementen.Add(new Element("79", " Au ", " Gold", " 196.966569(4)", "FFD123", "166", "144"));
        MendeljevElementen.Add(new Element("80", " Hg ", " Mercury", " 200.59(2)", "B8B8D0", "155", "149"));
        MendeljevElementen.Add(new Element("81", " Tl ", " Thallium", " 204.3833(2)", "A6544D", "196", "148"));
        MendeljevElementen.Add(new Element("82", " Pb ", " Lead", " 207.2(1)", "575961", "202", "147"));
        MendeljevElementen.Add(new Element("83", " Bi ", " Bismuth", " 208.98040(1)", "9E4FB5", "", "146"));
        MendeljevElementen.Add(new Element("84", " Po ", " Polonium", " [209]", "AB5C00", "", ""));
        MendeljevElementen.Add(new Element("85", " At ", " Astatine", " [210]", "754F45", "", ""));
        MendeljevElementen.Add(new Element("86", " Rn ", " Radon", " [222]", "428296", "", "145"));
        MendeljevElementen.Add(new Element("87", " Fr ", " Francium", " [223]", "420066", "", ""));
        MendeljevElementen.Add(new Element("88", " Ra ", " Radium", " [226]", "007D00", "", ""));
        MendeljevElementen.Add(new Element("89", " Ac ", " Actinium", " [227]", "70ABFA", "", ""));
        MendeljevElementen.Add(new Element("90", " Th ", " Thorium", " 232.03806(2)", "00BAFF", "", ""));
        MendeljevElementen.Add(new Element("91", " Pa ", " Protactinium", " 231.03588(2)", "00A1FF", "", ""));
        MendeljevElementen.Add(new Element("92", " U ", " Uranium", " 238.02891(3)", "008FFF", "186", ""));
        MendeljevElementen.Add(new Element("93", " Np ", " Neptunium", " [237]", "0080FF", "", ""));
        MendeljevElementen.Add(new Element("94", " Pu ", " Plutonium", " [244]", "006BFF", "", ""));
        MendeljevElementen.Add(new Element("95", " Am ", " Americium", " [243]", "545CF2", "", ""));
        MendeljevElementen.Add(new Element("96", " Cm ", " Curium", " [247]", "785CE3", "", ""));
        MendeljevElementen.Add(new Element("97", " Bk ", " Berkelium", " [247]", "8A4FE3", "", ""));
        MendeljevElementen.Add(new Element("98", " Cf ", " Californium", " [251]", "A136D4", "", ""));
        MendeljevElementen.Add(new Element("99", " Es ", " Einsteinium", " [252]", "B31FD4", "", ""));
        MendeljevElementen.Add(new Element("100", " Fm ", " Fermium", " [257]", "B31FBA", "", ""));
        MendeljevElementen.Add(new Element("101", " Md ", " Mendelevium", " [258]", "B30DA6", "", ""));
        MendeljevElementen.Add(new Element("102", " No ", " Nobelium", " [259]", "BD0D87", "", ""));
        MendeljevElementen.Add(new Element("103", " Lr ", " Lawrencium", " [262]", "C70066", "", ""));
        MendeljevElementen.Add(new Element("104", " Rf ", " Rutherfordium", " [267]", "CC0059", "", ""));
        MendeljevElementen.Add(new Element("105", " Db ", " Dubnium", " [268]", "D1004F", "", ""));
        MendeljevElementen.Add(new Element("106", " Sg ", " Seaborgium", " [271]", "D90045", "", ""));
        MendeljevElementen.Add(new Element("107", " Bh ", " Bohrium", " [272]", "E00038", "", ""));
        MendeljevElementen.Add(new Element("108", " Hs ", " Hassium", " [270]", "E6002E", "", ""));
        MendeljevElementen.Add(new Element("109", " Mt ", " Meitnerium", " [276]", "EB0026", "", ""));
    }
    public static Element getElement(string element) {
        foreach (Element e in MendeljevElementen) {
            if (element.Equals(e.abbreviation)){
                return e;
            }
        }       
        return null;
    }


}
