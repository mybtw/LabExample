#include"func_ptrs.h"
#include<cmath>

int dbl(int x) { return 2 * x; }

int equal(int x) { return x; }

void my_map(int* a, int* b, int size, IFnI f) {
	for (int i = 0; i < size; i++) {
		*(b + i) = f(*a + i);
	}
}

int plus_inc(int x){
	return x + Inc; 
}

int filterDouble(double* a, double* b, int size, Pred p) {
	int j = 0;
	for (int i = 0; i < size; i++) {
		if (p(*(a + i))) {
			*(b + j) = *(a + i);
			j++;
		}
	}
	return j;
}


bool IsPos(double x) { return x > 0; }

bool isCosNeg(double x) { return cos(x) < 0; }
// компаратор по убыванию
int myless(const void* a, const void* b) {

	 return (*(int*)b - *(int*)a);
}
// компаратор по возрастанию
int pos_cos(const void* a, const void* b) {
	
	double res = (cos(*(int*)a) - cos(*(int*)b));
	if (res < 0) return -1;
	else if (res > 0) return 1;
	else return 0;

}

// удваивает по ссылке
void my_double(int& a) {
	a *= 2;
	cout << a << " ";
}


void myhello() { cout << "Hello!" << endl; }
void myhoareu() { cout << "How are u?" << endl; }
void mygoodbye() { cout << "GoodBye!" << endl; }