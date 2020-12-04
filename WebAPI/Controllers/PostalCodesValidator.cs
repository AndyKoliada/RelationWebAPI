//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebAPI.ModelsConnected;

//namespace WebAPI.Controllers
//{
//    public class PostalCodesValidator
//    {
//        public void Validate()
//        {
//            string postalCodeFormatMask;

//            //if (relationModel.PostalCode != "" && relationModel.Country != "")
//            //{
//            //    postalCodeFormatMask = _context.Countries
//            //        .Where(n => n.Name == relationModel.Country && n.PostalCodeFormat != null)
//            //        .Select(n => n.PostalCodeFormat).FirstOrDefault();

//            //    relationModel.PostalCode = PostalCodeFormatter(postalCodeFormatMask);
//            //}

//            string PostalCodeFormatter(string postalCodeFormatMask)
//            {
//                //Расшифровка символов маски: N - digit, L - capital letter,
//                //l - lower letter.Например, если введенный почтовый индекс 4545bx,
//                //    а маска -"NNNN-LL", то в базе должно сохраниться значение 4545 - BX

//                string correctedPostalCode = relationModel.PostalCode;
//                string pc = relationModel.PostalCode;
//                string m = postalCodeFormatMask;

//                for (int i = 0; i < m.Length - 1; i++)
//                {
//                    for (int j = 0; j < pc.Length - 1; j++)
//                    {
//                        if (m[i] == 'N' && Char.IsDigit(pc[i]))
//                        {
//                            correctedPostalCode += pc[i];
//                        }
//                        else if (m[i] == 'l' && Char.IsLetter(pc[i]) && Char.IsLower(pc[i]))
//                        {
//                            correctedPostalCode += pc[i];
//                        }
//                        else if (m[i] == 'L' && Char.IsLetter(pc[i]) && Char.IsUpper(pc[i]))
//                        {
//                            correctedPostalCode += pc[i];
//                        }
//                        else if (m[i] == 'l' && Char.IsLetter(pc[i]) && Char.IsUpper(pc[i]))
//                        {
//                            correctedPostalCode += Char.ToLower(pc[i]);
//                        }
//                        else if (m[i] == 'L' && Char.IsLetter(pc[i]) && Char.IsLower(pc[i]))
//                        {
//                            correctedPostalCode += Char.ToUpper(pc[i]);
//                        }
//                    }
//                }


//                return correctedPostalCode;
//            }
//        }
//    }

