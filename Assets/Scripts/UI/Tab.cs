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
        public bool ShowOnMouseHovered;
        public bool tapToHide;
        public bool showOnStart;

        public Color color = Color.white;
        public Color selectedColor = Color.white;

        public Image background;
        public bool isShowing => tabGroup.currentSelection != null ? tabGroup.currentSelection == ID : false;
        void Start()
        {
            if(tabGroup)
                tabGroup.AddTab(this);
            GetComponent<Button>()?.onClick.AddListener(OnClick);
            ShowTab(showOnStart);
        }
        void OnClick()
        {
            tabGroup.ShowTab(ID, false, tapToHide);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (ShowOnMouseHovered  && !isShowing)
                tabGroup.ShowTab(ID, true, tapToHide);
        }
        public void UpdateColor(bool showing)
        {
            if(background)
                background.color = showing ? selectedColor : color;
        }
        public void ShowTab(bool show = true)
        {
            TabItem.SetActive(show);
            UpdateColor(show);
        }
    }

}
