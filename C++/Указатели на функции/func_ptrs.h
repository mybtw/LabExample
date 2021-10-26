#include<iostream>

using namespace std;
#ifndef func_ptrs
#define func_ptrs

typedef void (*VFnV)();
extern int Inc;
typedef int (*IFnI)(int);
void my_map(int* a, int* b, int size, IFnI f);

template<typename T>
void print_array(T const* arr, int size, char delim = ' ') {
    for (int i = 0; i < size; ++i)
        std::cout << arr[i] << delim;
    cout << endl;
}

// тождественная функция
int equal(int );
// увеличивает в 2 раза
int dbl(int );

//увеличивает на значение Inc
int plus_inc(int );

typedef bool (*Pred)(double);
int filterDouble(double* a, double* b, int size, Pred p);

// проверка на положительность
bool IsPos(double x);

//косинус отрицателен
bool isCosNeg(double x);

int myless(const void* a, const void* b);

int pos_cos(const void* a, const void* b);

void my_double(int& a);

void myhello();
void myhoareu();
void mygoodbye();


void execAll(VFnV* funcs, int size);
/* func_ptrs */
#endif
