#include<stdio.h>

int fact(int a){
    if(a == 1){
        return 1;
    }

    return a*fact(a-1);
}
void main(){
    int a = 5;
    int ans = fact(a);
    printf("%d", ans);    
}

