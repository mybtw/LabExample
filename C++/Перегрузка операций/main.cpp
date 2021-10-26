#include"Apple.h"
#include<iostream>
using namespace std;

int main() {
	Apple a{};
	//cin >> a;
	
	Apple b{};
	cin >> b;
	cout << "a==b ?" << endl;
	cout<< (a==b) <<endl;
	cout << "a!=b ?" << endl;
	cout << (a != b) << endl;
	b++;
	cout << (++b).color() << endl;
	cout << "After ++b and b++ color from 0 became: " << endl;
	cout << b.color() << endl;
	cout << "Two equal apples:" << endl;
	Apple l{ red,2 };
	Apple m{ red,2 };
	cout << "==" << endl;
	cout << (l == m) << endl;
	cout << "<=" << endl;
	cout << (l <= m) << endl;
	cout << "<" << endl;
	cout << (l < m) << endl;

}
/*2 5
a==b ?
0
a!=b ?
1
2
After ++b and b++ color from 0 became:
2
Two equal apples:
==
1
<=
1
<
0*/