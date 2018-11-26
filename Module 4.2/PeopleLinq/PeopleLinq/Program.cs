using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = Dataset.People;


            //1) Получить число мужчин в коллекции; число женщин

            int manCount = people.Where(p => p.Gender == Gender.Man).Count();
            int womanCount = people.Where(p => p.Gender == Gender.Woman).Count();

            //2) Отсортировать персонажей по фамилии потом по имени, выбрать их описание в формате $"{Name} {SurName}, age {Age} lives in {City}, {Country}. He (или she, решить тернарным опертором) is {Occupation} and makes {AnnualIncome} a year. {Family status to string}, speaks {Languages Count} languages

            string[] names = people.OrderBy(p => p.SurName)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} {p.SurName}, age {p.Age} lives in {p.HomeAddress.City.Name}, {p.HomeAddress.City.Country.Name}. {HeShe(p.Gender)} is {p.Occupation} and makes {p.AnnualIncome} a year. {p.FamilyStatus.ToString()}, speaks {p.Languages.Count()} language").ToArray();

            //3)Найти тех, кто живет в странах с  насилением больше 80 миллионов

            Person[] personCountry = people.Where(p => p.HomeAddress.City.Country.Population > 80000000).ToArray();

            //4) Найти средний доход в группе персонажей (return decimal Average()) с высшим образованием(выше HECert - аналого нашего двухгодичного "младшего специалиста")

            decimal d = people.Where(p => p.EducationLevel == EducationLevel.HECert).Average(p => p.AnnualIncome);

            //5) Найти тех, чей годовой доход превышает годовой доход в их стране

            Person[] personAvgIncome = people.Where(p =>  p.AnnualIncome >  p.HomeAddress.City.Country.AvgIncome).ToArray();

            //6) Найти максимальное число языков, которым владеет персонаж (return int Max()

            int max = people.Max(i => i.Languages.Count());

            //7) Найти виртуозного полиглота(для которого число языков равняется числу из п.6)

            Person person2 = people.FirstOrDefault(i => i.Languages.Count() == max);

            //8) Найти персонажа, который не владеет языком страны, в которой он проживает.Если такого нет - вернуть null


            Person person3 = people.FirstOrDefault(a => !people.Any(x => x.Languages.Contains(a.HomeAddress.City.Country.Language)));

            //9) Найти людей, проживающих в Германии, упорядочить по возрасту от большего до меньшего, выбрать в формате $"{Name} {Surname} {Age} {City}"

            string[] personDE = people.Where(p => p.HomeAddress.City.Country == Dataset.Countries["de"])
               .OrderByDescending(p => p.Age)
               .Select(p => $"{p.Name} {p.SurName} {p.Age} {p.HomeAddress.City}").ToArray();

            //10)Найти процентную долю тех, кто состоит в браке от общего числа персонажей

            int marriedCount = people.Where(p => p.FamilyStatus == FamilyStatus.Married).Count();
            int countAll = people.Count();

            decimal dd = marriedCount * 100 / countAll;

            //11) Найти тех, кто владеет двумя и более языками но получает зарплату ниже средней по их стране

            Person[] personL2 = people.Where(p => p.Languages.Count() > 2).Where(p => p.AnnualIncome < p.HomeAddress.City.Country.AvgIncome).ToArray();

            //12) Найти единственного кандидата наук, если такого нет либо если выборка больше 1 - вернуть ошибку

            Person personPhD = people.SingleOrDefault(p => p.EducationLevel == EducationLevel.PhD);

            //13) Найти людей из испаноговорящих стран, вернуть в формате $"{Name} {Occupation} {City} {Country}"

            string[] personES = people.Where(p => p.HomeAddress.City.Country.Language == Dataset.Langs["es"])
              .Select(p => $"{p.Name} {p.Occupation} {p.HomeAddress.City.Name} {p.HomeAddress.City.Country.Name}").ToArray();

            //14) Найти персонажа, который живет в городе с наименьшим населением (относительно места проживания других персонажей)

            Person person5 = people.FirstOrDefault(a => a.HomeAddress.City.Population == people.Min(p => p.HomeAddress.City.Population));

            //15) Найти персонажа, который живет в городе с наименьшим абсолютным населением(город с наименьшим населением в списке городов), если такого нет - вернуть налл

            Person person7 = people.FirstOrDefault(a => a.HomeAddress.City.Population == Dataset.Cities.Min(p => p.Value.Population));

            //17) Определить, какая доля людей, владеющих английским, проживает не в англоговорящих странах по отношению ко всем людям из списка, которые владеют английским

            int enCount = people.Where(p => p.HomeAddress.City.Country.Language != Dataset.Langs["en"]).Where(a => people.Any(x => x.Languages.Contains(Dataset.Langs["en"]))).Count();
            decimal ddd = enCount * 100  / countAll;

            //18) Найти самого богатого персонажа

            Person person = people.FirstOrDefault(a => a.AnnualIncome == people.Max(p => p.AnnualIncome));

            //19) Найти персонажа с наименьшим доходом в Британии

            Person personUK = people.Where(a => a.HomeAddress.City.Country == Dataset.Countries["uk"]).Where(a => a.AnnualIncome < people.Min(p => p.AnnualIncome)).FirstOrDefault();

            //20) Отсортировать персонажей по доходу по нисходящей, потом по имени и по фамилии по восходящей

            string[] person1 = people.OrderByDescending(p => p.AnnualIncome)
               .OrderBy(p => p.Name)
               .ThenBy(p => p.SurName)
               .Select(p => $"{p.Name} {p.SurName}").ToArray();
        }


        private static string HeShe(Gender gender)
        {
            string rez = gender == Gender.Man ? "He" : "She";

            return rez;
        }
    }
}
