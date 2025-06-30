#include<stdio.h>
#include<time.h>

void binary_search(int arr[], int n, int x){
    int flag = 0;
    int start = 0;
    int end = n;
    
    while(start <= end){
        int mid = start +(end -start)/2;

        if(arr[mid] == x){
            printf("enement found at %dth position", mid);
            return;
        }
        else if(arr[mid] > x){
            end = mid-1;
        }
        else{
            start = mid +1;
        }
    }
    
    if(flag == 0) printf("No element is found!!!");
    
}

void main(){
    int i=0;
    FILE* file;
    clock_t start,end;
    double cpu_time_used;
    int n = 100000;
    int arr[n];

    //worst case
    file = fopen("../Arrays/best_case_100000.txt","r");
    for(i=0;i<n;i++){
        fscanf(file,"%d",&arr[i]);
    }
    fclose(file);

    printf("Enter element to search: ");
    int x;
    scanf("%d", &x);

    start = clock();
    binary_search(arr,n,x);
    end = clock();
    cpu_time_used = ((double)(end - start)/CLOCKS_PER_SEC);
    printf("\nTime taken to Search element in Array Using binary search is : %f",cpu_time_used);
}