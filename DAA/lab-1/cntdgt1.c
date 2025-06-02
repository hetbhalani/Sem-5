#include<stdio.h>

void main(){
    int a = 12345;

    int cnt = 0;

    while(a != 0){
        a /= 10;
        cnt++;
    }

    printf("%d", cnt);
}