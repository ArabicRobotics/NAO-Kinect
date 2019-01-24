using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllNAO.NETV2
{
    public  class clsInitilizer
    {
    
        string DistenationDir = @"D:\NAOKinectControl\Main\Main\bin\Debug\dlls\";

        string sourcedir = @"D:\NAOKinectControl\dllNAO.NETV2\Dlls\dlls";
       


        public clsInitilizer()
        {
            try
            {
                /////////////Copy Dlls 
                DirectoryInfo dir = new DirectoryInfo(sourcedir);
                if (!System.IO.File.Exists(DistenationDir + "boost_atomic-vc120-mt-1_59.dll"))
                {
                    Directory.CreateDirectory(DistenationDir);
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        string temppath = Path.Combine(DistenationDir, file.Name);
                        try
                        {
                            file.CopyTo(temppath, false);
                        }
                        catch (Exception ex)
                        {


                        }

                    }
                }
            }
            //// Finished copy
            catch (Exception ex)
            {
                dllBasics.clsLog.Log(" Error while copy Robot Dlls " + ex.Message, 1);
                throw ex;
            }
            
        }
    }
}
