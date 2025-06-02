#include<stdio.h>

int jor(int a, int b){
    if(b == 0){
        return 1;
    }

    return a * jor(a,b-1);
}

void main(){
    printf("%d", jor(2,3));
}