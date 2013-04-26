using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for MD5
/// </summary>
public class MD5_encryption
{
    MD5 md5Hash = MD5.Create();

    public MD5_encryption()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public String encryptPas(string input)
    {
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes 
        // and create a string.
        StringBuilder paswoord = new StringBuilder();

        // Loop through each byte of the hashed data  
        // and format each one as a hexadecimal string. 
        for (int i = 0; i < data.Length; i++)
        {
            paswoord.Append(data[i].ToString("x2"));
        }
        return paswoord.ToString();
    }
}