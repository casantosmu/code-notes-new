const menuToggleBtn = document.querySelector("#menu-toggle");
const menuCloseBtn = document.querySelector("#menu-close");
const sidebarElm = document.querySelector("#sidebar");

const handleToggleSidebar = () => {
  sidebarElm.classList.toggle("js-open");
  document.body.classList.toggle("js-no-scroll");
};

const handleResize = (mediaQueryList) => {
  if (mediaQueryList.matches) {
    sidebarElm.classList.remove("js-open");
    document.body.classList.remove("js-no-scroll");
  }
};

const mediaQueryList = matchMedia("(min-width: 1024px)");
mediaQueryList.addEventListener("change", handleResize);

menuToggleBtn.addEventListener("click", handleToggleSidebar);
menuCloseBtn.addEventListener("click", handleToggleSidebar);
