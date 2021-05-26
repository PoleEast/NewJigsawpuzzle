while(1)  //停止
         {

             if(KEY1==0)
             {
                 Delay_ms(10);
                 if(KEY1==1)
                 {
                         if(count>99)
                 {
                 count =1;

                 }
                  LCD_Cmd(0x8A);
                LCD_Disp(count);
                count++;
                Delay_ms(1);



             }
             }
         };
 }
void LCD_Disp(unsigned int disp)  // LCD 十進制5位數顯示
{
 if(disp>9)    LCD_Data(disp % 100/10+'0');    //顯示十位數
                                LCD_Data(disp % 10+'0');        //顯示個位數
}