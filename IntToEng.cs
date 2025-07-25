public class Solution {
    public string NumberToWords(int num) {
        string[] numbers = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string[] DonVi = { "", "Thousand", "Million", "Billion" };
            string[] chuc = { "", "", "Twenty", "Thirty", "Forty", "Fifty",
                "Sixty", "Seventy", "Eighty", "Ninety" };
            int position = -1;
            string read = "";
            if (num == 0)
                read = numbers[num];
            else
            {
                while (num > 0)
                {
                    //Lấy 3 số cuối cùng trước, sau đó lấy 3 số nghìn, triệu, tỷ
                    long Group = num % 1000;
                    num /= 1000;
                    position++;

                    //Nếu ta có 3 số ở hàng trăm, chục, đơn vị đều là 0 thì sẽ không đọc. Ví dụ: 1000, 12000,...
                    if (Group == 0)
                        continue;
                    read = DonVi[position] + " " + read;
                    string readGr = "";
                    //xét các chữ số ở hàng trăm, chục và đơn vị
                    long[] Temp = { (Group / 100), (Group / 10) % 10, Group % 10 };
                    //Giả sử temp[0] là số 3 thì sẽ lấy phần tử thứ 3 của mảng So (So[3]) và phần tử đầu của mảng Hang
                    //để đọc là trăm

                    if (Temp[0] != 0)
                        readGr += (numbers[Temp[0]]) + " " +  "Hundred";
                    //trường hợp hàng chục bằng 0 nhưng hàng đơn vị khác 0 sẽ có chữ lẻ
                    //if (Temp[1] == 0)
                    //{
                    //    if (Temp[2] != 0)
                    //        readGr += "lẻ ";
                    //}
                    //Trường hợp hàng chục = 1 sẽ đọc là mười ...
                    //Còn các trường hợp còn lại sẽ đọc theo vị trí ở các mảng So[] + Hang[]
                    #region Xét các trường hợp của hàng chục
                    if (Temp[1] == 1)
                    {
                        switch (Temp[2])
                        {
                            case 0:
                                if(Temp[0] != 0)
                                    readGr += " Ten" + " ";
                                else
                                    readGr += "Ten" + " ";
                                break;
                            case 1:
                                if (Temp[0] != 0)
                                    readGr += " Eleven" + " ";
                                else
                                    readGr += "Eleven" + " ";
                                break;
                            case 2:
                                if (Temp[0] != 0)
                                    readGr += " Twelve" + " ";
                                else
                                    readGr += "Twelve" + " ";
                                break;
                            case 3:
                                if (Temp[0] != 0)
                                    readGr += " Thirteen" + " ";
                                else
                                    readGr += "Thirteen ";
                                break;
                            case 5:
                                if(Temp[0] != 0)
                                    readGr += " Fifteen" + " ";
                                else
                                    readGr += "Fifteen" + " ";
                                break;
                            case 4:
                            case 6:
                            case 7:
                            case 9:
                                if(Temp[0] != 0)
                                    readGr += " " + (numbers[Temp[2]]) + "teen" + " ";
                                else
                                    readGr += (numbers[Temp[2]]) + "teen" + " ";
                                break;
                            case 8:
                                if(Temp[0] != 0)
                                    readGr += " " + (numbers[Temp[2]]) + "een" + " ";
                                else
                                    readGr += (numbers[Temp[2]]) + "een" + " ";
                                break;
                        }
                    }
                    #endregion
                    //Số hàng chục bằng 0
                    else if(Temp[1] == 0)
                    {
                        if (Temp[0] == 0 && Temp[2] != 0)
                            readGr += numbers[Temp[2]] + " ";
                        else if (Temp[0] != 0 && Temp[2] == 0)
                            readGr += " ";
                        else if (Temp[2] != 0)
                            readGr += " " + numbers[Temp[2]] + " ";
                    }    
                    //Số hàng chục khác 0 và 1
                    else
                    {
                        if (Temp[0] != 0)
                        {
                            readGr += " ";
                            if (Temp[2] != 0)
                                readGr += (chuc[Temp[1]] + " " + numbers[Temp[2]]) + " ";
                            else
                                readGr += (chuc[Temp[1]]) + " ";
                        }
                        else
                        {
                            if (Temp[2] != 0)
                                readGr += (chuc[Temp[1]] + " " + numbers[Temp[2]]) + " ";
                            else
                                readGr += (chuc[Temp[1]]) + " ";
                        }
                    }
                    //Trường hợp hàng đơn vị khác 0 thì đọc số, nếu bằng 0 thì không cần đọc
                    //if (Temp[2] != 0)
                    //{
                    //    readGr += numbers[Temp[2]];
                    //}
                    read = readGr + read;
                }
                //Xét trường hợp người dùng nhập số 0 đầu tiên. Ví dụ: 01000, 0123, 09461,...
                if (read[0] == 'Z' && num > 0)
                {
                    //Xóa chữ "không", "trăm" kèm cái kí tự khoảng trắng của chúng
                    read = read.Remove(0, 5);
                    //Nếu cả 2 hàng trăm, chục đều bằng 0
                    //if (read[0] == 'l')
                    //    read = read.Remove(0, 3);
                }
            }
            read = read.Trim();
        return read;
    }
}
