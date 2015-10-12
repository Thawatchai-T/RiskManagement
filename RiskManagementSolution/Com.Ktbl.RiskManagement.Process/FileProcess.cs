using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Com.Ktbl.RiskManagement.Domain;
using Com.Ktbl.RiskManagement.Domain.Common;
using DataStreams.Csv;
using Nvv.IO.CSV.Cs;

namespace Com.Ktbl.RiskManagement.Process
{
    public class FileProcess
    {
        public List<BatchRiskDomain> LoadFromFile()
        {
            fileToLoad = "C:\\_Lab\\batch1.csv";
            
            List<BatchRiskDomain> le = new List<BatchRiskDomain>();
            using (CSVFileReader csvReader = new CSVFileReader())
            {
                csvReader.FileName = fileToLoad; // Assign CSV data file path
               
                // Modify values of other input properties if necessary. For example:
                csvReader.HeaderPresent = true;

                csvReader.Open();

                if (csvReader.HeaderPresent)
                    for (int i = 0; i < csvReader.FieldCount; i++)
                    {
                        // Process field names csvReader.Fields[i].Name. For example:
                        Console.WriteLine("Name{0}={1}", i, csvReader.Fields[i].Name);
                    }


                while (!csvReader.Eof)
                {

                    var entity = new BatchRiskDomain();

                    for (int i = 0; i < csvReader.FieldCount; i++)
                    {
                       
                       
                        if (Columns.CID.ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.CId = csvReader.Fields[i].Value;
                        }

                        if (Columns.BusinessType.ToString().Equals(csvReader.Fields[i].Name)){
                            entity.BusinessType = csvReader.Fields[i].Value;
                        }

                        if (Columns.OccupationCatelogy.ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.OccupationCatelogy = csvReader.Fields[i].Value;
                        }

                        if (Columns.OccupationGroup.ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.OccupationGroup = csvReader.Fields[i].Value;
                        }

                        if (Columns.OccupationType.ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.OccupationType = csvReader.Fields[i].Value;
                        }

                        if (Columns.Position.ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.Position = csvReader.Fields[i].Value;
                        }

                        
                    }

                    entity.CreateBy = "woody";
                    entity.UpdateBy = "woody";
                    entity.CreateDate = DateTime.Now;
                    entity.UpdateDate = DateTime.Now;
                    entity.RefFile = fileToLoad;
                    le.Add(entity);
                    csvReader.Next();
                }

                csvReader.Close(); //Recommended but optional if within "using"

                return le;
            }

        }

        public List<StandardCodeDomain> LoadFromFileStandardCode()
        {
            fileToLoad = "C:\\_Lab\\standard_type.csv";

            List<StandardCodeDomain> le = new List<StandardCodeDomain>();
            using (CSVFileReader csvReader = new CSVFileReader())
            {
                csvReader.FileName = fileToLoad; // Assign CSV data file path

                // Modify values of other input properties if necessary. For example:
                csvReader.HeaderPresent = true;

                csvReader.Open();

                if (csvReader.HeaderPresent)
                    for (int i = 0; i < csvReader.FieldCount; i++)
                    {
                        // Process field names csvReader.Fields[i].Name. For example:
                        Console.WriteLine("Name{0}={1}", i, csvReader.Fields[i].Name);
                    }


                while (!csvReader.Eof)
                {

                    var entity = new StandardCodeDomain();

                    for (int i = 0; i < csvReader.FieldCount; i++)
                    {


                        if ("Standard_Type".Equals(csvReader.Fields[i].Name))
                        {
                            entity.StandardType = csvReader.Fields[i].Value;
                        }

                        if ("Standard_Code".ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.StandardCode = csvReader.Fields[i].Value;
                        }

                        if ("Standard_Name".ToString().Equals(csvReader.Fields[i].Name))
                        {
                            entity.StandardName = csvReader.Fields[i].Value;
                        }


                    }

                    le.Add(entity);
                    csvReader.Next();
                }

                csvReader.Close(); //Recommended but optional if within "using"

                return le;
            }

        }


        public string fileToLoad { get; set; }

        public enum Columns{
            Id = 0,
            CID = 1,
            OccupationCatelogy = 2,
            OccupationGroup = 3,
            OccupationType = 4,
            Position = 5,
            BusinessType = 6
        }
    }
}
