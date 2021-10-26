#include"func_ptrs.h"
#include<iostream>
#include<cstdlib>
using namespace std;
int Inc = 2;
int main() {

	cout << "Task 1" << endl;
	int* a = new int[5]{ 1,2,3,4,5 };
	int* b = new int[5];
	my_map(a, b, 5, equal);
	print_array(b, 5);
	my_map(a, b, 5, dbl);
	print_array(b, 5);
	my_map(a, b, 5, plus_inc);
	print_array(b, 5);
	cout << "---------------" << endl;

	
	cout << "Task 2" << endl;
	double* a1 = new double[5]{ 1.1, -2, 3.8, -4.6, 7 };
	double* b1 = new double[5];
	print_array(a1,5);
	int l1 = filterDouble(a1, b1, 5, IsPos);
	cout << "Pos: " << l1 << endl;
	print_array(b1, l1);
	int l2 = filterDouble(a1, b1, 5, isCosNeg);
	cout << "Cos < 0: " << l2 << endl;
	print_array(b1, l2);
	cout << "---------------" << endl;


	cout << "Task 3" << endl;
	int* a2 = new int[4]{ -1,2,-3,5 };
	int* b2 = new int[4];
	qsort(a2, 4,sizeof(int), myless);
	print_array(a2,4);
	qsort(a2, 4, sizeof(int), pos_cos);
	print_array(a2, 4);
	cout << "---------------" << endl;

	cout << "Task 4" << endl;
	cout << "Enter numbers end. by 0: " << endl;
	int n;
	cin >> n;
	while (n != 0) {
		my_double(n);
		cin >> n;
	}
	cout << endl;
	cout << "---------------" << endl;

	cout << "Task 5" << endl;
	VFnV arrFuncs[] = { myhello, myhoareu, mygoodbye };
	for (auto x : arrFuncs)
	{
		x();
	}
	cout << "---------------" << endl;
}
/*Task 1
1 2 3 4 5
2 4 6 8 10
3 4 5 6 7
---------------
Task 2
1.1 -2 3.8 -4.6 7
Pos: 3
1.1 3.8 7
Cos < 0: 3
-2 3.8 -4.6
---------------
Task 3
5 2 -1 -3
-3 2 5 -1
---------------
Task 4
Enter numbers end. by 0:
1 2 3 4 5 0
2 4 6 8 10
---------------
Task 5
Hello!
How are u?
GoodBye!
---------------*/