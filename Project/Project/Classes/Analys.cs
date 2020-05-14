using System;
using System.Collections.Generic;


namespace Project.Classes
{
    public class Analys
    {
        public DateTime lastSurvey { get; set; }
        public Dictionary<string, double> titles { get; set; }

        /*
        public Dictionary<string, double> titles = new Dictionary<string, double>
        {
            {"CD3+CD-19(Тл)", 0},
            {"CD3-CD19+(Вл)", 0},
            {"CD3+CD4+(Th)", 0},
            {"CD3+CD8+(Tc)", 0},
            {"CD3-CD8+", 0},
            {"CD4+CD8+", 0},
            {"CD4/CD8 индекс", 0},
            {"CD3+DR+", 0},
            {"CD3+DR-", 0},
            {"коэфф. акт. T лимф.", 0},
            {"CD8+DR+", 0},
            {"3-16+56+(NK)", 0},
            {"3+16+56+(NK-T)", 0},
            {"CD19+CD5+", 0},
            {"CD19+CD5-", 0},
            {"CD62L+CD4+", 0},
            {"CD62L-CD4+(инд Вл)", 0},
            {"CD25+CD4+(спонт)", 0},
            {"CD14+DR+(мон)", 0},
            {"CD3-Cd19-16-56", 0},
            {"CD3+CD4-CD8-y^σ", 0},
            {"45+14-(лимф.Регион)", 0},
            {"Общие лимфоциты", 0},
            {"СОЭ(мм/ч)", 0},
            {"Hb(г/л)", 0},
            {"Лейкоциты/мкл", 0},
            {"Эритроциты / мкл", 0},
            {"Пал", 0},
            {"Сег", 0},
            {"Эоз", 0},
            {"Баз", 0},
            {"Лимф", 0},
            {"Мон", 0},
        };
        */

        public Analys(DateTime lastSurvey)
        {
            this.lastSurvey = lastSurvey;
            this.titles = new Dictionary<string, double>();
        }

        public void addTitles(string key, double value)
        {
            titles.Add(key, value);
        }
    }
}
