using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalscedHashing
{
    class Searching
    {
        int input;
        int[] indexData, indexLink;
        const int kosong = -1;
        string hasil;


        public int[] IndexData
        {
            get
            {
                return this.indexData;
            }
            set
            {
                this.indexData = value;
            }
        }

        public int[] IndexLink
        {
            get
            {
                return this.indexLink;
            }
            set
            {
                this.indexLink = value;
            }
        }

        public Searching(int[] _indexData, int[] _indexLink, int _input)
        {
            IndexData = _indexData;
            IndexLink = _indexLink;
            input = _input;
        }

        public String prosesSearching(int bilangan)
        {
            int addr, count;

            count = 1;
            addr = bilangan % input;
            hasil = hasil + "MENCARI BILANGAN : " + bilangan+"\n";
            while (bilangan != kosong)
            {
                hasil = hasil + "\nLANGKAH " + count + "\n\n";
                hasil =(count == 1)? hasil + "ADDR <-- " + bilangan + " mod " + input+"\n":hasil + "";
                hasil = hasil + "ADDR <-- " + addr+"\n";
                if (indexData[addr] != kosong)
                {
                    hasil = hasil + "M(" + addr + ") = Kosong ? T\n";
                    if (IndexData[addr] == bilangan)
                    {
                        hasil = hasil + "M(" + addr + ") = " + bilangan + " ? Y\n";
                        hasil = hasil + "DATA ADA\n";
                        bilangan = kosong;
                    }
                    else
                    {
                        hasil = hasil + "M(" + addr + ") = " + bilangan + " ? T\n";
                        if (IndexLink[addr] != kosong)
                        {
                            hasil = hasil + "M(" + addr + ").Link = Kosong ? T\n";
                            addr = IndexLink[addr];
                            hasil = hasil + "ADDR <-- " + addr + "\n";
                        }
                        else
                        {
                            hasil = hasil + "M(" + addr + ").Link = Kosong ? Y\n";
                            hasil = hasil + "DATA TIDAK ADA\n";
                            bilangan = kosong;
                        }
                    }
                }
                else {
                    hasil = hasil + "M(" + addr + ") = Kosong ? Y\n";
                    hasil = hasil + "DATA TIDAK ADA\n";
                    bilangan = kosong;
                }
                count++;
            }
            return hasil; 
        }

    }
}
