function $(element) {
   var obj=document.getElementById(element);
   if(obj=null)
   {
    obj=document.getElementByName(element);
   }
   return obj;
}
//���Ʋ����ʾ������
 function changeType(divId)
    {
        var obj = document.getElementById(divId);
        var pinbiObj = document.getElementById("pinBi");
        if(obj.className=="showDiv")
        {
            
            obj.className = "hiddenDiv";
            pinBi.className="hiddenDiv";
        }
        else if(obj.className=="hiddenDiv")
        {
                 
            obj.className="showDiv";
            pinBi.className="showDiv";
        }
    }
//�����ק
var  ms=0;  
function  MoveWithMouse(divId){
           ms = divId;  
           event.srcElement.setCapture();  
           x=document.all(ms).style.pixelLeft-window.event.clientX;  
           y=document.all(ms).style.pixelTop-window.event.clientY;
           }  
 
function  document.onmousemove(){  
           if(ms!=""){  
                       document.all(ms).style.pixelLeft=x+window.event.clientX;  
                       document.all(ms).style.pixelTop=y+window.event.clientY;
                       }  
           }  
 
function  document.onmouseup(){  
           if(ms!=""){  
                       event.srcElement.releaseCapture();  
                       ms=0;  
                       }  
           } 
//��֤
function checkInput(inputId,messageId){
    if($(inputId).value=="")
    {
        $(messageId).className="showDiv";
        return false;
    }
}
//�޸Ĺ�����״̬
function changeToolBarStatus()
{
	var btn = document.getElementById("btnChangeToolBar");
	var myDiv = document.getElementById("toolBar");
	if(myDiv.className=="hiddenDiv")
	{
		btn.innerText = "���ع�����";
		myDiv.className="showDiv";
	}
	else
	{
		btn.innerText = "��ʾ������";
		myDiv.className="hiddenDiv";
	}
}