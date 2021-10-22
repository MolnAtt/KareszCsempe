using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Karesz
{
    public partial class Form1 : Form
    {
        void Hátra_arc()
        { 
            Fordulj(jobbra);
            Fordulj(jobbra);
        }

        void Lépj(int db)
        {
            for (int i = 0; i < db; i++)
            {
                Lépj();
            }
        }
        void Hátra_lépj(int db)
        {
            Hátra_arc();
            Lépj(db);
            Hátra_arc();
        }

        void Csík(int db, int szín)
        {
            for (int i = 0; i < db; i++)
            {
                Tegyél_le_egy_kavicsot(szín);
                Lépj();
            }
            Hátra_lépj(db);
        }

        void Oldalazz(int irany, int db)
        {
            Fordulj(irany);
            Lépj(db);
            Fordulj(-irany);
        }

        void négyzet(int méret, int szín)
        {
            for (int i = 0; i < méret; i++)
            {
                Csík(méret, szín);
                Oldalazz(jobbra, 1);
            }
            Oldalazz(balra, méret);
        }

        int Másik(int szín)
        {
            if (szín == piros)
            {
                return zöld;
            }
            else
            {
                return piros;
            }
        }

        int Másik2(int szín)
        {
            return szín == piros ? zöld : piros;
        }

        int Másik3(int szín) => szín == piros ? zöld : piros;

        void Csempesor(int db, int négyzetméret, int szín)
        {
            for (int i = 0; i < db; i++)
            {
                if (i%2==0)
                {
                    négyzet(négyzetméret, szín);
                }
                else
                {
                    négyzet(négyzetméret, Másik(szín));
                }
                Oldalazz(jobbra, négyzetméret);
            }
            Oldalazz(balra, négyzetméret * db);
        }
        void Csempezés(int szélesség, int magasság, int mekkora, int szín)
        {
            for (int i = 0; i < magasság; i++)
            {
                Csempesor(szélesség, mekkora, szín);
                Lépj(mekkora);
                szín = Másik(szín);
            }
        }
        void FELADAT()
        {
            Csempezés(7, 7, 3, piros);
        }
    }
}