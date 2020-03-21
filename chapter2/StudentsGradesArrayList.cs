using System;
using System.Collections;

namespace chapter2 {
    class StudentsGradesArrayList {
        //分数
        ArrayList grades;
        //数据数量
        int max;
        public StudentsGradesArrayList()
        {
            max = 10000000;
            grades = new ArrayList();
        }
        public void Start()
        {
            InsertGrades();
            Timing timing = new Timing();
            timing.StartTime();
            AnalysisGrades();
            timing.StopTime();
            Console.WriteLine($"ArrayList{max/10000}万条查询耗时{timing.Result().TotalSeconds}秒");
            Console.WriteLine("");
        }
        //录入成绩
        public void InsertGrades()
        {
            for (float i = 0; i < max; i++) {
                grades.Add(i); 
            }
        }
        //分析成绩
        public void AnalysisGrades()
        {
            float total = 0f;//总分
            float bottom = max + 1f;//假设不存在这么高的分数,跟我判断最低分的逻辑有关
            float top = -1f;//假设不存在负分数,跟我判断最高分的逻辑有关
            int count = 0;
            foreach (float temp in grades) {
               total += temp;
                if (top < temp) {
                    top = temp;
                }
                if (bottom > temp) {
                    bottom = temp;
                }
                count++;
            }
            if (count == 0) {
                Console.WriteLine("没录分呢大哥");
            }
            else {

            }
            Console.WriteLine($"平均分{total / count}最低分{bottom}最高分{top}");
        }
    }
}
