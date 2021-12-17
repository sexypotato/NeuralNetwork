using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISLab3
{
    public class HiddenLayer : Layer // Класс скрытого слоя
    {
        public HiddenLayer(int non, int nopn, NeuronType nt, string type) : base(non, nopn, nt, type) { } // Конструктор слоя
        public override void Recognize(Network net, Layer nextLayer) 
        {
            double[] hidden_out = new double[Neurons.Length]; //Создаём массив на выход
            for (int i = 0; i < Neurons.Length; ++i)
                hidden_out[i] = Neurons[i].Output; //Копируем массив входных данных системы на выход слоя
            nextLayer.Data = hidden_out; //Передаём для второго слоя массив входных данных
        }
        public override double[] BackwardPass(double[] gr_sums) //Обратный проход и коррекция весов
        {
            double[] gr_sum = new double[numofprevneurons];
            for (int j = 0; j < gr_sum.Length; ++j)
            {
                double sum = 0;
                for (int k = 0; k < Neurons.Length; ++k)
                    sum += Neurons[k].Weights[j] * Neurons[k].Derivative * gr_sums[k];//через градиентные суммы и производную
                gr_sum[j] = sum;
            }
            for (int i = 0; i < numofneurons; ++i)
                for (int n = 0; n < numofprevneurons + 1; ++n)
                {
                    double deltaw = (n == 0) ? (momentum * lastdeltaweights[i, 0] + learningrate * Neurons[i].Derivative * gr_sums[i]) : (momentum * lastdeltaweights[i, n] + learningrate * Neurons[i].Inputs[n - 1] * Neurons[i].Derivative * gr_sums[i]);
                    lastdeltaweights[i, n] = deltaw;
                    Neurons[i].Weights[n] += deltaw;//коррекция весов
                }
            return gr_sum;
        }
    }
}
