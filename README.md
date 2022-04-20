# Final-Project-Assignment
**ความเป็นมาของโปรแกรม**

``
เป็นโปรแกรมในการจัดการการขายPOS(Point of sale) การคิดบริการต่างๆ คิดคำนวณค่าภาษี(Tax)ในการบริการ รวมถึงเงินทอน ในการใช้บริการสินค้าโดยPos ที่นำมาวันนี้ใช้้เป็นการจัดการร้านคาเฟ่
``

**วัตถุประสงค์ของโปรแกรม**

``
1.เพื่อคำนวณสินค้าจำนวนมากๆในการใช้บริการต่อครั้ง
``

``
2.เพื่อไม่ให้เกิดการผิดดพลาดในการคำนวณ ยอดในการบริการแต่ละครั้ง
``

**Class Diagram**
```mermaid
classDiagram
Pay <|-- Form1
Exit <|-- Form1
Form1 <|-- Menu
      Form1 : +Double Cost
      Form1 : +Double Change
      Form1 : +String Menu
      Form1: +total()
      Form1: +tax()
      class Menu{
          +String Cakechocolate
          +String Espresso
          +String Americano
          +String Americano
          +String Greentea
          +String Milktea
          +String Bubblemilktea
          +String Limesoda
          +String Salalemonsoda
          +String BlueHawaiisoda
          +String Bingsu
          +String MixedFruitCake
          +String StrawberryCake
          +CostofItem()
          +Amount()
}
class Pay{
+Cost()
+Tax()
}
class Exit{
-Close()
}
```
**ผู้พัฒนาโปรแกรม**

``
นาย เทวารัณย์ ชัยกิจ รหัสนักศึกษา 643450324-6
``


   
      


      
