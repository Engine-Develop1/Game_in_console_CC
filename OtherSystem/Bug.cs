using System;
using System.Collections.Generic;
using System.Text;

namespace game_in_console.bug
{
    public enum Bugs
    {
        shop = 019, //< 019
        craft = 101, //< 010
        item = 717, //< 717
        inv = 231, //< 231
        Dev = 404 //< 404
    }
    public static class Bug
    {
        public static void MessBug(string ErrorCode, Bugs bugs)
        {
            string common = "please message the creator on discord in the " +
                "BjornBEs Server or on twitter at @BjornBEs1 \n " +
                "in the message set the the first line to" + 
                @" ""Bug in Game"" #CG" + ErrorCode + 
                " and he will answer as fast as he can";
            string commonDev = "please do not be so dum that you can not do you password but \n" +
                "message the creator on discord in the \n" +
    "BjornBEs Server or on twitter at @BjornBEs1 \n " +
    "in the message set the the first line to" +
    @" ""Bug in Game"" #CG7934" + "dev-0d7108675515642088282343560593016681706084177530656008353111232967989516307290384282497646993753157772076312922503059484669509389173831043955479395698123870738" +
    " and he will answer as fast as he can";
            switch (bugs)
            {
                case Bugs.shop:
                    if(ErrorCode == "01920")
                        Console.WriteLine("Error: \n " +
                "Shop data can't find item \n " + common);
                    break;
                case Bugs.craft:
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (ErrorCode == "01001")
                        Console.WriteLine("Error: \n " + "system can't find Crafting item \n " + common);
                    if (ErrorCode == "01010")
                        Console.WriteLine("Error: \n " + "System can't find Result item \n " + common);
                    if (ErrorCode == "01011")
                        Console.WriteLine("Error: \n " + "System take all items \n " + common);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Bugs.item:
                    break;
                case Bugs.inv:
                    break;
                case Bugs.Dev:
                        Console.WriteLine("Error: \n " +
                "You are not a Dev \n " + commonDev);
                    Console.WriteLine("0b10000100100101100101101111011101010010000001100001011100100110010100100000011011100110111101110100001000000110000100100000011001000110010101110110001000010010001000010010001011100010111000101110");
                    break;
                default:
                    break;
            }
            //Console.WriteLine(craft.CraftintItems);
            Console.Title = "error... #CG" + ErrorCode;
        }
    }
}
