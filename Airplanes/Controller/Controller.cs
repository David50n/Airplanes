using Airplanes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Airplanes.Conntroller
{
    internal class RController
    {
        public List<Construct> Airplanes { get; set; }
        private string Way;

        public RController(string way)
        {
            Way = way;
            Airplanes = RunRecord();
        }

        private List<Construct> RunRecord()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(Way, FileMode.OpenOrCreate))
                {
                    List<Construct> rec = formatter.Deserialize(fs) as List<Construct>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<Construct>();
                }
            }
            catch (SerializationException ex)
            {
                return new List<Construct>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RecordFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(Way, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Airplanes);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string name, string type, string DOC, string maxheight, string color)
        {
            Airplanes.Add(new Construct(name, type, DOC, maxheight, color));
            try
            {
                RecordFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
