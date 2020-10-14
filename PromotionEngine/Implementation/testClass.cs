using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine.Implementation
{
    class testClass
    {
        public static List<string> processData(IEnumerable<string> lines)
        {
            static int ConvertToInt(string obj)
            {
                int.TryParse(obj, out var intVal);
                return intVal;
            }
            var splittedLines = lines.Select(obj => obj.Split(','));
            splittedLines.ToList().ForEach(obj => obj.ToList().ForEach(o=> o.Trim()));
            var discountedRows = splittedLines.GroupBy(obj => obj[3]).SelectMany(obj =>
            obj.Where(obj1 =>
                            obj1[3] == obj.Key &&
                            ConvertToInt(obj1[4]) < obj.Max(obj => ConvertToInt(obj[4]))).
                  Select(a => a)).Distinct().ToList();
            var finalRows = discountedRows.GroupBy(obj => obj[3]).SelectMany(
                obj => obj.Where(obj1 => obj1[3] == obj.Key && ConvertToInt(obj1[4]) == obj.Min(obj => ConvertToInt(obj[4]))).
                  Select(a => a[0])).Distinct().ToList();
            return finalRows;
        }
        IF(not EXISTS (SELECT*
                 FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'ExamScore'))
BEGIN
    create table dbo.ExamScore(CandidateId Integer not null, paperid integer not null, Score Integer not null)
END
IF(not EXISTS (SELECT*
                 FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'Paper'))
begin
    create table dbo.Paper(Paperid integer not null, PaperName Char(20) not null)
end

IF(not EXISTS (SELECT*
                 FROM INFORMATION_SCHEMA.TABLES
                 WHERE TABLE_SCHEMA = 'dbo'
                 AND TABLE_NAME = 'Candidate'))
begin
    create table dbo.Candidate(CandidateId integer not null, CandidateName char(20) not null)
end


select avg(pp.score) from(
select avg(score) as score , paperid p
from ExamScore
where PaperId<100
group by PaperId)
 pp
    }
}
