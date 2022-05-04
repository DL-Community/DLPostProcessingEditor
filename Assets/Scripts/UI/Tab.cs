using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Tab
{
    public class Tab : MonoBehaviour, IPointerEnterHandler
    {
        public int ID { get; set; }
        public TabGroup tabGroup;
        public GameObject TabItem;
        public bool ShowOnMouseHovered = true;
        public bool isShowing => TabItem != null && TabItem.activeInHierarchy;
        void Start()
        {
            if(tabGroup)
                tabGroup.AddTab(this);
            GetComponent<Button>()?.onClick.AddListener(OnClick);
            TabItem.SetActive(false);
        }
        void OnClick()
        {
            ShowThis();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (ShowOnMouseHovered && tabGroup.isCurrentShowing && !isShowing)
                tabGroup.ShowTab(ID);
        }
        void ShowThis()
        {
            if (!isShowing)
                tabGroup.ShowTab(ID);
            else if(isShowing)
                tabGroup.CloseAllTabs();
        }
    }

}
