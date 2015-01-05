using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoalscedHashing
{
    class Inserting
    {
        int input;
        int[] indexData, indexLink, indexBilangan;
        bool isPrima;
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

        public int[] IndexBilangan
        {
            get
            {
                return this.indexBilangan;
            }
            set
            {
                this.indexBilangan = value;
            }
        }

        public int Input
        {
            get
            {
                return this.input;
            }
            set
            {
                this.input = value;
            }
        }

        public Inserting(int jumlahBilangan, int[] _indexBilangan)
        {
            indexBilangan = _indexBilangan;
            input = cariBilanganPrima(jumlahBilangan);
            IndexData = new int[input];
            IndexLink = new int[input];
            resetIndex();
        }

        public String prosesInput()
        {
            int addr = 0;
            int count = 1;

            for (int i = 0; i < indexBilangan.Length; i++)
            {
                count = 1;
                hasil = hasil + "\n\nMEMASUKKAN BILANGAN " + indexBilangan[i] + "\n\n";

                addr = indexBilangan[i] % input;
                while (indexBilangan[i] != kosong)
                {
                    
                    hasil = (count == 1) ? hasil + "ADDR <-- " + indexBilangan[i] + " mod " + input + "\n" : hasil + "";
                    hasil = hasil + "ADDR <-- " + addr + "\n";

                    if (IndexData[addr] == kosong)
                    {
                        hasil = hasil + "M(" + addr + ") = Kosong ? Y\n";
                        IndexData[addr] = indexBilangan[i];
                        IndexBilangan[i] = kosong;
                        hasil = hasil + "M(" + addr + ") <-- "+indexData[addr]+"\n";
                    }
                    else
                    {
                        hasil = hasil + "M(" + addr + ") <-- Kosong ? T\n";
                        if (IndexLink[addr] == kosong)
                        {
                            hasil = hasil + "M(" + addr + ").Link <-- Kosong ? Y\n";
                            for (int j = 0; j < input; j++)
                            {
                                if (IndexData[j] == kosong)
                                {
                                    hasil = hasil + "M(t) <-- Kosong ? Y\n";
                                    hasil = hasil + "t = "+j+"\n";
                                    IndexLink[addr] = j;
                                    IndexData[j] = IndexBilangan[i];
                                    IndexBilangan[i] = kosong;
                                    hasil = hasil + "M(" + j + ") <-- " + indexData[j] + "\n";
                                    hasil = hasil + "M(" + addr + ").Link <-- " + j + "\n";
                                    break;
                                }

                            }
                        }
                        else
                        {
                            hasil = hasil + "M(" + addr + ").Link = Kosong ? T\n";
                            addr = indexLink[addr];
                            hasil = hasil + "ADDR <-- " + addr + "\n";
                        }
                    }
                    count++;
                }

            }
            return hasil;
        }

        public void resetIndex()
        {
            for (int i = 0; i < indexData.Length; i++)
            {
                indexData[i] = kosong;
                IndexLink[i] = kosong;
            }
        }


        public int cariBilanganPrima(int _input)
        {
            while (isPrima == false)
            {
                isPrima = true;
                _input++;
                for (int i = 2; i <= _input; i++)
                {
                    isPrima = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrima = false;
                            break;
                        }
                    }
                }
            }
            return _input;
        }

    }
}
