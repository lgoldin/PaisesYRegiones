var fixGridWidth = function (grid, container) {
    if (grid[0]) {
        var gviewScrollWidth = grid[0].parentNode.parentNode.parentNode.scrollWidth;
        var mainWidth = jQuery(container ? container : '.container').width();
        if (mainWidth != gviewScrollWidth) {
            grid.jqGrid("setGridWidth", mainWidth);
            $('#gbox_' + grid[0].id).css("width", "+=3");
        }
    }
};