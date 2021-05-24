/*numero 1*/
Select amount.AMOUNT, CONCAT(e.FIRST_NAME,' ' , e.LAST_NAME) as FULL_NAME,
IIF(DATEDIFF(year, e.START_DATE, COALESCE(e.END_DATE, GETDATE())) >= 5, 'Old Employee', 'New Employee') as HIRED_STATUS
from Employee e
inner join
(Select AMOUNT, TELLER_EMP_ID from ACC_TRANSACTION where EXECUTION_BRANCH_ID = 
(Select Branch_ID from Branch where Name = 'Quincy Branch') 
AND AMOUNT > 100 and AMOUNT < 1000) as amount
on e.EMP_ID = amount.TELLER_EMP_ID
order by amount.AMOUNT desc

/*numero 2*/
select employeeData.DEPARTMENT_NAME, employeeData.FULL_NAME, transactionData.AVERAGE, transactionData.TOTAL
from
(select AVG(t.AMOUNT) as AVERAGE, COUNT(*) as TOTAL, t.TELLER_EMP_ID
from ACC_TRANSACTION as t
inner join
BRANCH as b
on t.EXECUTION_BRANCH_ID = b.BRANCH_ID
where DATEDIFF(year, t.TXN_DATE, GETDATE()) between 0 and 19
and b.NAME = 'Headquarters'
group by t.TELLER_EMP_ID) transactionData
inner join
(select e.EMP_ID, CONCAT(e.FIRST_NAME,' ' , e.LAST_NAME) as FULL_NAME, d.NAME as DEPARTMENT_NAME
from DEPARTMENT as d
inner join 
EMPLOYEE as e
on d.DEPT_ID = e.DEPT_ID) employeeData
on transactionData.TELLER_EMP_ID = employeeData.EMP_ID
order by transactionData.AVERAGE, transactionData.TOTAL desc
