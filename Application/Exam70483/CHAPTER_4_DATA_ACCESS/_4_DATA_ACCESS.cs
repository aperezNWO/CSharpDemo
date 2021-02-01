using System;

namespace _4_DataAccess
{

    /// <summary>
    /// CLASE PARA PRUEBAS POR LINEA DE COMANDOS
    /// </summary>
    public class _4_DATA_ACCESS
    {
        public static void Skill_4_1()
        {
            //
            // _4_0_Database_Test.Run();
            //

            Console.WriteLine("Skill 4.1 - Performing I/O Operations");
            //
            //_4_1_INPUT_OPTUPUT_OPS.FileStreamTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.StreamReaderWriterTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.GZipTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.FileClassTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.FileInfoTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.DirectoryInfoTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.FilePathTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.SearchFilesTest();
            //
            //_4_1_INPUT_OPTUPUT_OPS.WebRequestTest();
            //
            //_ = _4_1_INPUT_OPTUPUT_OPS.WebClientTestAsync();
            //
            //_ = _4_1_INPUT_OPTUPUT_OPS.HttpClientTest();
            //
            _ = Skill_4_1_INPUT_OPTUPUT_OPS.FileAsyncTest();
            //
        }
        //
        public static void Skill_4_2(string[] args)
        {
            //
            Console.WriteLine("Skill 4.2 - [Consume Data]");
            //
            // Skill_4_2_Consume_Data.ReadWithSqlTest(args);
            //
            //_ = Skill_4_2_Consume_Data.AsyncDatabaseTest();
        }
        //
        public static void Run(string[] args)
        {
            //
            Console.WriteLine("CHAPTER 4 - IMPLEMENING DATA ACCESS");
            //
            //Skill_4_1();
            //
            Skill_4_2(args);
            //
        }
    }
}
