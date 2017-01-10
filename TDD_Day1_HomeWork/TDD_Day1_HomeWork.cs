using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Day1_HomeWork
{
    public class TDD_Day1_HomeWork
    {
        List<object> _dataGroup = null;
        public TDD_Day1_HomeWork()
        {
            _dataGroup = new List<object>
            {
                new { Id=1, Cost=1,Revenue=11,SellPrice=21},
                new { Id=2, Cost=2,Revenue=12,SellPrice=22},
                new { Id=3, Cost=3,Revenue=13,SellPrice=23},
                new { Id=4, Cost=4,Revenue=14,SellPrice=24},
                new { Id=5, Cost=5,Revenue=15,SellPrice=25},
                new { Id=6, Cost=6,Revenue=16,SellPrice=26},
                new { Id=7, Cost=7,Revenue=17,SellPrice=27},
                new { Id=8, Cost=8,Revenue=18,SellPrice=28},
                new { Id=9, Cost=9,Revenue=19,SellPrice=29},
                new { Id=10, Cost=10,Revenue=20,SellPrice=30},
                new { Id=11, Cost=11,Revenue=21,SellPrice=31}
            };
        }
        public void InitialData<T>(List<T> dataGroup)
        {
            _dataGroup = dataGroup.Cast<object>().ToList();
        }
        /// <summary>
        /// 幾筆一組和選取的property進行加總
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count">幾筆一組</param>
        /// <param name="expression">欄位</param>
        /// <returns></returns>
        public List<int> GetProductGroup<T>(int count, Expression<Func<T, object>> expression)
        {
            //取得欄位名稱
            var body = expression.Body as MemberExpression;
            if (body == null)
                body = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            var field = body.Member.Name;

            //根據組別進行加總
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int index = 0; index < _dataGroup.Count; index++)
            {
                var value = (int)_dataGroup[index].GetType().GetProperty(field).GetValue(_dataGroup[index]);
                var key = index / count;
                result[key] = result.ContainsKey(key) ? result[key] + value : value;
            }
            return result.Values.ToList();
        }
    }
}
