using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    enum Gender { Male, Female }
    class FamilyMember
    {
        public string name { get; set; }
        public Gender gender { get; set; }
        public FamilyMember[] children { get; set; }
        public FamilyMember mother { get; set; }
        public FamilyMember father { get; set; }

        public FamilyMember()
        {
        }

        public FamilyMember(string name, Gender gender, FamilyMember mother, FamilyMember father, params FamilyMember[]? familyMembers)
        {
            this.name = name;
            this.gender = gender;
            this.mother = mother;
            this.father = father;
            this.children = familyMembers;
        }

        public void MothersInFamily()
        {
            FamilyMember adult = this;

            if (adult.mother != null)
            {
                adult = adult.children.Length > 0 && adult.children[0].mother != null ? adult.children[0].mother : this;
            }

            while (adult.mother != null)
                adult = adult.mother;

            if (adult.gender == Gender.Female)
                Console.Write($"{adult.name} -> ");


            bool femaleChild = true;
            while (femaleChild)
            {
                femaleChild = false;
                Console.Write($"{adult.name} -> ");

                foreach (FamilyMember child in adult.children)
                    if (child.gender == Gender.Female)
                    {
                        adult = child;
                        femaleChild = true;
                        break;
                    }
            }
        }

        public void PrintFamily()
        {
            FamilyMember secondMember = null;
            if (this.children != null)
                secondMember = this.gender == Gender.Male ? this.children[0].mother : this.children[0].father;
            if (secondMember != null)
                PrintFamily(this, secondMember);
            else
                PrintFamily(this);

        }

        private void PrintFamily(params FamilyMember[] familyMembers)
        {
            List<FamilyMember> children = new List<FamilyMember>();
            foreach (FamilyMember familyMember in familyMembers)
                Console.Write($"{familyMember.name} ");
            Console.WriteLine();
            foreach (FamilyMember familyMember in familyMembers)
            {
                if (familyMember.children != null)
                {
                    foreach (FamilyMember child in familyMember.children)
                    {
                        if (child.children != null)
                        {
                            foreach (FamilyMember child2 in child.children)
                            {
                                FamilyMember second = child.gender == Gender.Male ? child2.mother : child2.father;
                                if (second != null && !children.Contains(second))
                                    children.Add(second);
                            }

                        }
                        if (!children.Contains(child))
                            children.Add(child);
                    }
                }
            }
            if (children.Count > 0)
                PrintFamily(children.ToArray());
        }

        /**
         * Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран близких 
        родственников(жену/мужа) и братьев/сестёр определённого человека.
        Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек.
         */
        
        private List<FamilyMember> brothersAndSisters ()
        {
            List<FamilyMember> listBrothersAndSisters = new List<FamilyMember>();
            FamilyMember mother = this.mother;
            FamilyMember father = this.father;

            if (mother != null)
            {
                foreach (FamilyMember children in mother.children)
                {
                    if (children.name != this.name) { 
                        listBrothersAndSisters.Add(children);
                    }
                }
            }
            if (father != null)
            {
                foreach (FamilyMember children in father.children)
                {
                    if (!listBrothersAndSisters.Contains(children) && children.name != this.name) { listBrothersAndSisters.Add(children); }
                }
            }
            return listBrothersAndSisters;
        }

        private List<FamilyMember> husbandsAndWives ()
        {
            List<FamilyMember> listHusbandsAndWives = new List<FamilyMember>();
            FamilyMember[] childrens = this.children;

            if (childrens != null)
            {
                foreach (FamilyMember children in childrens)
                {
                    if (this.gender == Gender.Male)
                    {
                        if (!listHusbandsAndWives.Contains(children.mother) && children.mother != null) { listHusbandsAndWives.Add(children.mother); }                            
                    }
                    else if (!listHusbandsAndWives.Contains(children.father) && children.father != null) { listHusbandsAndWives.Add(children.father); }
                }
            }
            return listHusbandsAndWives;
        }
        public void CloseRelatives()
        {
            List<FamilyMember> listBrothersAndSisters = new List<FamilyMember>(brothersAndSisters());
            List<FamilyMember> listHusbandsAndWives = new List<FamilyMember>(husbandsAndWives());

            string relative;
            string showRelative;

            Console.WriteLine($"Член семьи: {this.name}");
            for (int i = 0; i < listBrothersAndSisters.Count; i++)
            {
                if (listBrothersAndSisters[i].gender == Gender.Male)
                {
                    relative = "Брат:";
                    showRelative = String.Format("\n{0,-10} |{1,5}|", relative, listBrothersAndSisters[i].name);
                    Console.Write(showRelative);
                }
                else
                {
                    relative = "Сестра:";
                    showRelative = String.Format("\n{0,-10} |{1,5}|", relative, listBrothersAndSisters[i].name);
                    Console.Write(showRelative);
                }
            }

            for (int i = 0; i < listHusbandsAndWives.Count; i++)
            {
                if (listHusbandsAndWives[i].gender == Gender.Male)
                {
                    relative = "Муж:";
                    showRelative = String.Format("\n{0,-10} |{1,5}|", relative, listHusbandsAndWives[i].name);
                    Console.Write(showRelative);
                }
                else
                {
                    relative = "Жена:";
                    showRelative = String.Format("\n{0,-10} |{1,5}|", relative, listHusbandsAndWives[i].name);
                    Console.Write(showRelative);
                }
            }
        }
    }
}