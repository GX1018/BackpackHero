# BackpackHero

- 2023.02.18. : IPointerDownHandler,IPointerUpHandler 를 사용해 아이템 클릭 여부를 확인중에 마우스 좌/우 클릭 구분 없이 입력을 받는 
                문제 발생, 
                이 문제로 인해 좌클릭으로 드래그 도중 우클릭을 하였을때 OnPointerUp()함수가 실행되어 드래그가 풀리게 됨.
                해결 방안 :  IPointerDownHandler,IPointerUpHandler를 사용하지 않고 Input.GetMouseButtonDown(), Input.GetMouseButtonUp()으로 좌/우 클릭의 구분을 인식 할 수 있게 수정하려고함. (x)
                OnPointerDown(),OnPointerUp() 함수 내부에 좌/우 클릭 입력시 체크할 수 있는 조건을 부여해서 //if(Input.GetMouseButtonDown(0)), if(Input.GetMouseButtonDown(1))
                클릭별 행동을 구분하였음.

- 2023.02.23. : [itemTest.cs] 캐릭터 애니메이션 관련
                사용아이템 횟수 0일때  destroy로 설정하여 파괴시 SetTrigger("UseItemEnd") 실행 x 아이템 애니메이션 컨트롤을 다른곳에서 해야할것
                charactermanager에서 컨트롤 하도록 변경 예정