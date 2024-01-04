﻿using System.Reflection;

namespace Homework_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamilyMember grandfather = new() { mother = null, father = null, name = "Дедушка", gender = Gender.Male };
            FamilyMember grandmother = new() { mother = null, father = null, name = "Бабушка", gender = Gender.Female };
            FamilyMember father = new FamilyMember() { mother = grandmother, father = grandfather, name = "Отец", gender = Gender.Male };
            FamilyMember brother = new FamilyMember() { mother = grandmother, father = grandfather, name = "Брат отца", gender = Gender.Male };
            FamilyMember sister = new FamilyMember() { mother = null, father = grandfather, name = "Сестра отца", gender = Gender.Male };
            FamilyMember mother = new FamilyMember() { mother = null, father = null, name = "Мама", gender = Gender.Female };
            FamilyMember mother2 = new FamilyMember() { father = null, mother = null, name = "Мама2", gender = Gender.Female };
            FamilyMember son = new FamilyMember() { mother = mother, father = father, name = "Сын", gender = Gender.Male };
            FamilyMember son2 = new FamilyMember() { father = father, mother = mother2, name = "Сын2", gender = Gender.Male };




            grandfather.children = new FamilyMember[] { father, brother, sister };
            grandmother.children = new FamilyMember[] { father, brother };
            mother2.children = new FamilyMember[] { son2 };
            mother.children = new FamilyMember[] { son };
            father.children = new FamilyMember[] { son, son2 };



            //grandfather.PrintFamily();

            grandfather.CloseRelatives();

        }
    }
}
