using System.Text;

namespace Cars;



public class CustomEncodingProvider : EncodingProvider
{
    public override Encoding GetEncoding(int codepage)
    {
        if (codepage == 1251) 
        {
            return Encoding.GetEncoding("windows-1251");
        }
        // Добавьте другие кодировки, если необходимо

        return null;
    }

    public override Encoding GetEncoding(string name)
    {
        if (name.ToLower() == "windows-1251")
        {
            return Encoding.GetEncoding("windows-1251");
        }
        // Добавьте другие кодировки, если необходимо

        return null; 
    }
}

