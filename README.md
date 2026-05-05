# Probability & Statistical Distributions – Programming Assignment

**Faculty of Computers and Information**  
**Course:** Probability and Statistical Distributions  
**Semester:** Spring 2025/2026  
**Student:** Moaz Ezzat Abbas (معاذ عزت عباس)  
**Instructor:** Prof. Samir Elmougy  
**Due Date:** Thursday, May 7, 2026

---

## Description

This project contains two C# programming tasks:

### Task 1 – Statistical Computations
Given the dataset:
```
115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110
```

The program computes:
| # | Statistic |
|---|-----------|
| i | Mean |
| ii | Mode |
| iii | Median |
| iv | Variance |
| v | P20 (20th Percentile) |
| vi | P50 (50th Percentile) |
| vii | Third Quartile (Q3) |
| viii | Second Quartile (Q2) |
| ix | Third Quartile (Q3) |
| x | Range |
| xi | Interquartile Range (IQR) |
| xii | Standard Deviation |
| xiii | Summation of Divisions (Σ xi/mean) |

### Task 2 – Outlier Detection
Checks each input number and classifies it as **Outlier** or **Normal** using the IQR method:
- **Lower Fence** = Q1 − 1.5 × IQR  
- **Upper Fence** = Q3 + 1.5 × IQR

---

## How to Run

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Steps
```bash
git clone https://github.com/<your-username>/StatisticsAssignment.git
cd StatisticsAssignment
dotnet run
```

---

## Sample Output

```
=======================================================
   Probability & Statistical Distributions Assignment  
   Student: Moaz Ezzat Abbas                          
=======================================================

Input Data:
115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83, 21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109, 105, 183, 110

(i)   Mean                 = 163.8000
(ii)  Mode                 = 21
(iii) Median               = 179.0000
...
```

---

## License
Academic assignment – All rights reserved © Moaz Ezzat Abbas, 2026
