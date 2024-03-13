using System;
using System.IO;
using WeaponsLib;

public class Programm
{
    static void Main(string[] args)
    {
        Sword excalibur = new Sword("Excalibur", 2.5, 50, 10, false);
        Console.WriteLine(excalibur);
        excalibur.Sharpening();
        excalibur.Strike("Goblin");
        excalibur.Enchant();

        Axe battleAxe = new Axe("Battle Axe", 4.0, 40, 8, 30);
        Console.WriteLine(battleAxe);
        battleAxe.Sharpening();
        battleAxe.ExtendHandle(10);
        battleAxe.Strike("Elf");

        Caliber caliber9mm = new Caliber("9*19", 24);

        Caliber caliber762mm = new Caliber("7.62*39", 48);

        Pistol glock17 = new Pistol("Glock 17", 0.905, 300, caliber9mm, 17, false);

        Rifle akm = new Rifle("AKM", 2.5, 600, caliber762mm, 30, 400);

        akm.Shoot("Goblin");

        Console.WriteLine(akm);

        glock17.Shoot("Goblin");

        Console.WriteLine(glock17);

        Console.WriteLine(akm);

        akm.Reload();

        Console.WriteLine(akm);


    }
}