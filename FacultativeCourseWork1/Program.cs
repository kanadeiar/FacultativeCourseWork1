using FacultativeCourseWork1.Array_s;
using System;

namespace FacultativeCourseWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBestArray.PrintNameProgramme();
            MyBestArray.firstDimension = MyBestArray.ValidateNumberLine();
            MyBestArray.secondDimension =MyBestArray.ValidateNumberColumn();
            MyBestArray.arrayUser = MyBestArray.CreateArray(MyBestArray.arrayUser, MyBestArray.firstDimension, MyBestArray.secondDimension);
            MyBestArray.ShowMenuV2();
        }
    }
}
