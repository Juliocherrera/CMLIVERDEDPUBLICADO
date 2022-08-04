using APPLIVERDEDCM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLIVERDEDCM
{
    public class Program
    {
        public facLabController facLabControler = new facLabController();
        static void Main(string[] args)
        {

            Program archivo = new Program();
            archivo.Extraer();
        }
        public class Students
        {
            public string Name { get; set; }
        }
        public void Extraer()
        {

            string[] values;
            DataTable tbl = new DataTable();
            DirectoryInfo di24 = new DirectoryInfo(@"\\10.223.208.41\Users\Administrator\Documents\LIVERDED");
            //DirectoryInfo di24 = new DirectoryInfo(@"C:\Administración\Proyecto LIVERDED\Ordenes");
            FileInfo[] files24 = di24.GetFiles("*.dat");

            int cantidad24 = files24.Length;
            if (cantidad24 > 0)
            {
                foreach (var item in files24)
                {
                    string sourceFile = @"\\10.223.208.41\Users\Administrator\Documents\LIVERDED\" + item.Name;
                    //string sourceFile = @"C:\Administración\Proyecto LIVERDED\Ordenes\" + item.Name;
                    string Ai_orden = item.Name.Replace(".dat", "");
                    string Av_weightunit = "KGM";

                    int counter = 1;
                    foreach (string line in File.ReadLines(sourceFile, Encoding.Default))
                    {
                        if (counter > 1)
                        {
                            values = line.Split('|');
                            string col1 = values[0];
                            string col2 = values[1];
                            string col3 = values[2];
                            string col4 = values[3];
                            string col5 = values[4];
                            string col6 = values[5];
                            string Av_cmd_code = values[6];
                            string Av_cmd_description = values[7];
                            string Af_count = values[8];
                            string Av_countunit = values[9];
                            string col11 = values[10];
                            string col12 = values[11];
                            string col13 = values[12];
                            string col14 = values[13];
                            string col15 = values[14];
                            string Af_weight = values[15];
                            string col17 = values[16];
                            string col18 = values[17];
                            string col19 = values[18];
                            if (Av_cmd_code != "")
                            {
                                //facLabControler.getMercancias(Ai_orden, Av_cmd_code, Av_cmd_description, Af_weight, Av_weightunit, Af_count, Av_countunit);
                                facLabControler.GetMerc(Ai_orden, Av_cmd_code, Av_cmd_description, Af_weight, Av_weightunit, Af_count, Av_countunit);
                                facLabControler.DeleteMerc(Ai_orden);
                            }
                        }
                        counter++;
                    }
                    string destinationFile = @"\\10.223.208.41\Users\Administrator\Documents\LIVERDEDUPLOADS\" + item.Name;
                    //string destinationFile = @"C:\Administración\Proyecto LIVERDED\Procesadas\" + item.Name;
                    System.IO.File.Move(sourceFile, destinationFile);
                }
            }
        }
    }
}
