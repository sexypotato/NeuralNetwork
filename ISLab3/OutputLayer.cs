using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLab3
{
    public class OutputLayer : Layer //Выходной слой
    {
        public OutputLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type) { }
        public override void Recognize(Network net, Layer nextLayer) // для последнего слоя
        {
            double e_sum = 0;  //количество заполненных клеточек
            for (int i = 0; i < Neurons.Length; ++i) //считаем
                e_sum += Neurons[i].Output;
            for (int i = 0; i < Neurons.Length; ++i)
                net.fact[i] = Neurons[i].Output / e_sum; //Формирование выходного массива
        }
        public override double[] BackwardPass(double[] errors) // Обратный проход
        {
            double[] gr_sum = new double[numofprevneurons + 1];
            for (int j = 0; j < gr_sum.Length; ++j)//вычисление градиентных сумм выходного слоя
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; ++k)
                    sum += Neurons[k].Weights[j] * errors[k];
                gr_sum[j] = sum;
            }
            for (int i = 0; i < numofneurons; ++i)
                for (int n = 0; n < numofprevneurons + 1; ++n)
                {
                    double deltaw = (n == 0) ? (momentum * lastdeltaweights[i, 0] + learningrate * errors[i]) : (momentum * lastdeltaweights[i, n] + learningrate * Neurons[i].Inputs[n - 1] * errors[i]);
                    lastdeltaweights[i, n] = deltaw;
                    Neurons[i].Weights[n] += deltaw;//коррекция весов
                }
            return gr_sum;
        }
    }
}
