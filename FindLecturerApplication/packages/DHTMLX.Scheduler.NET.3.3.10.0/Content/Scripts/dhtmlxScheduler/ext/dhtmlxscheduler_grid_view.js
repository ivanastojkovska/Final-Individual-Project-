/*
@license
dhtmlxScheduler.Net v.3.3.10 

This software is covered by DHTMLX Evaluation License. Contact sales@dhtmlx.com to get Commercial or Enterprise license. Usage without proper license is prohibited.

(c) Dinamenta, UAB.
*/
Scheduler.plugin(function(e){!function(){e._grid={sort_rules:{"int":function(e,t,i){return 1*i(e)<1*i(t)?1:-1},str:function(e,t,i){return i(e)<i(t)?1:-1},date:function(e,t,i){return new Date(i(e))<new Date(i(t))?1:-1}},_getObjName:function(e){return"grid_"+e},_getViewName:function(e){return e.replace(/^grid_/,"")}}}(),e.createGridView=function(t){function i(e){return!(void 0!==e&&(1*e!=e||0>e))}var n=t.name||"grid",a=e._grid._getObjName(n);e.config[n+"_start"]=t.from||new Date(0),e.config[n+"_end"]=t.to||new Date(9999,1,1),
e[a]=t,e[a].defPadding=8,e[a].columns=e[a].fields,e[a].unit=t.unit||"month",e[a].step=t.step||1,delete e[a].fields;for(var r=e[a].columns,s=0;s<r.length;s++)i(r[s].width)&&(r[s].initialWidth=r[s].width),i(r[s].paddingLeft)||delete r[s].paddingLeft,i(r[s].paddingRight)||delete r[s].paddingRight;e[a].select=void 0===t.select?!0:t.select,void 0===e.locale.labels[n+"_tab"]&&(e.locale.labels[n+"_tab"]=e[a].label||e.locale.labels.grid_tab),e[a]._selected_divs=[],e.date[n+"_start"]=function(i){return e.date[t.unit+"_start"]?e.date[t.unit+"_start"](i):i;

},e.date["add_"+n]=function(t,i){return e.date.add(t,i*e[a].step,e[a].unit)},e.templates[n+"_date"]=function(t,i){return e.templates.day_date(t)+" - "+e.templates.day_date(i)},e.templates[n+"_full_date"]=function(t,i,a){return e.isOneDayEvent(a)?this[n+"_single_date"](t):e.templates.day_date(t)+" &ndash; "+e.templates.day_date(i)},e.templates[n+"_single_date"]=function(t){return e.templates.day_date(t)+" "+this.event_date(t)},e.templates[n+"_field"]=function(e,t){return t[e]},e.attachEvent("onTemplatesReady",function(){
e.attachEvent("onDblClick",function(t,i){return this._mode==n?(e._click.buttons.details(t),!1):!0}),e.attachEvent("onClick",function(t,i){return this._mode==n&&e[a].select?(e._grid.unselectEvent("",n),e._grid.selectEvent(t,n,i),!1):!0});var t=e.render_data;e.render_data=function(i){return this._mode!=n?t.apply(this,arguments):void e._grid._fill_grid_tab(a)};var i=e.render_view_data;e.render_view_data=function(){var t=e._els.dhx_cal_data[0].lastChild;return this._mode==n&&t&&(e._grid._gridScrollTop=t.scrollTop),
i.apply(this,arguments)}}),e[n+"_view"]=function(t){if(e._grid._sort_marker=null,delete e._gridView,e._grid._gridScrollTop=0,e._rendered=[],e[a]._selected_divs=[],t){var i=null,r=null,s=e[a];s.paging?(i=e.date[n+"_start"](new Date(e._date)),r=e.date["add_"+n](i,1)):(i=e.config[n+"_start"],r=e.config[n+"_end"]),e._min_date=i,e._max_date=r,e._grid.set_full_view(a);var d="";+i>+new Date(0)&&+r<+new Date(9999,1,1)&&(d=e.templates[n+"_date"](i,r)),e._els.dhx_cal_date[0].innerHTML=d,e._gridView=a}}},e.dblclick_dhx_grid_area=function(){
!this.config.readonly&&this.config.dblclick_create&&this.addEventNow()},e._click.dhx_cal_header&&(e._old_header_click=e._click.dhx_cal_header),e._click.dhx_cal_header=function(t){if(e._gridView){var i=t||window.event,n=e._grid.get_sort_params(i,e._gridView);e._grid.draw_sort_marker(i.originalTarget||i.srcElement,n.dir),e.clear_view(),e._grid._fill_grid_tab(e._gridView,n)}else if(e._old_header_click)return e._old_header_click.apply(this,arguments)},e._grid.selectEvent=function(t,i,n){if(e.callEvent("onBeforeRowSelect",[t,n])){
var a=e._grid._getObjName(i);e.for_rendered(t,function(t){t.className+=" dhx_grid_event_selected",e[a]._selected_divs.push(t)}),e._select_id=t}},e._grid._unselectDiv=function(e){e.className=e.className.replace(/ dhx_grid_event_selected/,"")},e._grid.unselectEvent=function(t,i){var n=e._grid._getObjName(i);if(n&&e[n]._selected_divs)if(t){for(var a=0;a<e[n]._selected_divs.length;a++)if(e[n]._selected_divs[a].getAttribute("event_id")==t){e._grid._unselectDiv(e[n]._selected_divs[a]),e[n]._selected_divs.slice(a,1);

break}}else{for(var a=0;a<e[n]._selected_divs.length;a++)e._grid._unselectDiv(e[n]._selected_divs[a]);e[n]._selected_divs=[]}},e._grid.get_sort_params=function(t,i){var n=t.originalTarget||t.srcElement,a="desc";"dhx_grid_view_sort"==n.className&&(n=n.parentNode),n.className&&-1!=n.className.indexOf("dhx_grid_sort_asc")||(a="asc");for(var r=0,s=0;s<n.parentNode.childNodes.length;s++)if(n.parentNode.childNodes[s]==n){r=s;break}var d=null;if(e[i].columns[r].template){var o=e[i].columns[r].template;d=function(e){
return o(e.start_date,e.end_date,e)}}else{var l=e[i].columns[r].id;"date"==l&&(l="start_date"),d=function(e){return e[l]}}var _=e[i].columns[r].sort;return"function"!=typeof _&&(_=e._grid.sort_rules[_]||e._grid.sort_rules.str),{dir:a,value:d,rule:_}},e._grid.draw_sort_marker=function(t,i){"dhx_grid_view_sort"==t.className&&(t=t.parentNode),e._grid._sort_marker&&(e._grid._sort_marker.className=e._grid._sort_marker.className.replace(/( )?dhx_grid_sort_(asc|desc)/,""),e._grid._sort_marker.removeChild(e._grid._sort_marker.lastChild)),
t.className+=" dhx_grid_sort_"+i,e._grid._sort_marker=t;var n="<div class='dhx_grid_view_sort' style='left:"+(+t.style.width.replace("px","")-15+t.offsetLeft)+"px'>&nbsp;</div>";t.innerHTML+=n},e._grid.sort_grid=function(t){var t=t||{dir:"desc",value:function(e){return e.start_date},rule:e._grid.sort_rules.date},i=e.get_visible_events();return i.sort("desc"==t.dir?function(e,i){return t.rule(e,i,t.value)}:function(e,i){return-t.rule(e,i,t.value)}),i},e._grid.set_full_view=function(t){if(t){var i=(e.locale.labels,
e._grid._print_grid_header(t));e._els.dhx_cal_header[0].innerHTML=i,e._table_view=!0,e.set_sizes()}},e._grid._calcPadding=function(t,i){var n=(void 0!==t.paddingLeft?1*t.paddingLeft:e[i].defPadding)+(void 0!==t.paddingRight?1*t.paddingRight:e[i].defPadding);return n},e._grid._getStyles=function(e,t){for(var i=[],n="",a=0;t[a];a++)switch(n=t[a]+":",t[a]){case"text-align":e.align&&i.push(n+e.align);break;case"vertical-align":e.valign&&i.push(n+e.valign);break;case"padding-left":void 0!==e.paddingLeft&&i.push(n+(e.paddingLeft||"0")+"px");

break;case"padding-right":void 0!==e.paddingRight&&i.push(n+(e.paddingRight||"0")+"px")}return i},e._grid._fill_grid_tab=function(t,i){for(var n=(e._date,e._grid.sort_grid(i)),a=e[t].columns,r="<div>",s=-2,d=0;d<a.length;d++){var o=e._grid._calcPadding(a[d],t);s+=a[d].width+o,d<a.length-1&&(r+="<div class='dhx_grid_v_border' style='left:"+s+"px'></div>")}r+="</div>",r+="<div class='dhx_grid_area'><table>";for(var d=0;d<n.length;d++)r+=e._grid._print_event_row(n[d],t);r+="</table></div>",e._els.dhx_cal_data[0].innerHTML=r,
e._els.dhx_cal_data[0].lastChild.scrollTop=e._grid._gridScrollTop||0;var l=e._els.dhx_cal_data[0].getElementsByTagName("tr");e._rendered=[];for(var d=0;d<l.length;d++)e._rendered[d]=l[d]},e._grid._print_event_row=function(t,i){var n=[];t.color&&n.push("background:"+t.color),t.textColor&&n.push("color:"+t.textColor),t._text_style&&n.push(t._text_style),e[i].rowHeight&&n.push("height:"+e[i].rowHeight+"px");var a="";n.length&&(a="style='"+n.join(";")+"'");for(var r=e[i].columns,s=e.templates.event_class(t.start_date,t.end_date,t),d="<tr class='dhx_grid_event"+(s?" "+s:"")+"' event_id='"+t.id+"' "+a+">",o=e._grid._getViewName(i),l=["text-align","vertical-align","padding-left","padding-right"],_=0;_<r.length;_++){
var h;h=r[_].template?r[_].template(t.start_date,t.end_date,t):"date"==r[_].id?e.templates[o+"_full_date"](t.start_date,t.end_date,t):"start_date"==r[_].id||"end_date"==r[_].id?e.templates[o+"_single_date"](t[r[_].id]):e.templates[o+"_field"](r[_].id,t);var c=e._grid._getStyles(r[_],l),u=r[_].css?' class="'+r[_].css+'"':"";d+="<td style='width:"+r[_].width+"px;"+c.join(";")+"' "+u+">"+h+"</td>"}return d+="<td class='dhx_grid_dummy'></td></tr>"},e._grid._print_grid_header=function(t){for(var i="<div class='dhx_grid_line'>",n=e[t].columns,a=[],r=n.length,s=e._obj.clientWidth-2*n.length-20,d=0;d<n.length;d++){
var o=1*n[d].initialWidth;isNaN(o)||""===n[d].initialWidth||null===n[d].initialWidth||"boolean"==typeof n[d].initialWidth?a[d]=null:(r--,s-=o,a[d]=o)}for(var l=Math.floor(s/r),_=["text-align","padding-left","padding-right"],h=0;h<n.length;h++){var c=a[h]?a[h]:l;n[h].width=c-e._grid._calcPadding(n[h],t);var u=e._grid._getStyles(n[h],_);i+="<div style='width:"+(n[h].width-1)+"px;"+u.join(";")+"'>"+(void 0===n[h].label?n[h].id:n[h].label)+"</div>"}return i+="</div>"}});