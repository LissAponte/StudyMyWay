
namespace StudyMyWay.wwwroot.js
{
   
        window.browser = {
            openExternal: (url, target) => {
                try {
                    wndow.open(url, target);
                }
                catch (e) {
                    console.error("Failed to open external link:", e);
                }
            }
        }
    
}
