using System.IO;

namespace FCamara.ProximaParada.Data.Context
{
    public static class ProximaParadaContext
    {
        //retornar o arquivo
        public static FileInfo Obter(string arquivoTxt)
        {
            string caminho = string.Format(@"{0}\{1}",
                Path.GetFullPath("../../../FCamara.ProximaParada.Data/Data"), arquivoTxt);
            FileInfo file = new FileInfo(caminho);
            
            return file;
        }
    }
}
