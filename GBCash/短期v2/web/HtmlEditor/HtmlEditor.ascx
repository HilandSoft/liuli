<%@ Control Language="c#" AutoEventWireup="false" Codebehind="HtmlEditor.ascx.cs" Inherits="YingNet.ControlLib.HtmlEditor.HtmlEditor" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link rel="stylesheet" href="/htmleditor/ew_includes/ew_styles.css" type="text/css">
<textarea style="display:none" id='myEditWorksControl_src'>
<link rel="stylesheet" href="/htmleditor/ew_includes/ew_styles.css" type="text/css">
<script language="JavaScript" src="/htmleditor/ew_includes/ro_attributes.js" type="text/javascript"></script>
<script language="JavaScript" src="/htmleditor/ew_includes/ro_xml.js" type="text/javascript"></script>
<script language="JavaScript" src="/htmleditor/ew_includes/ro_stringbuilder.js" type="text/javascript"></script>
<script>  
  //init
  var filemanageurl = '<%=FileManageURL %>';
  //init end

  var tableDefault = 1
  var useBR = 1
  var useXHTML = "1"
  var ContextMenuWidth = 162
  var URL = ""
  
  var sTxtGuidelines = "虚框"
  var sTxtOn = "打开"
  var sTxtOff = "关闭"
  var sTxtClean = "确定要清理HTML代码吗？"
  
 // var re3 = /src="http:\/\/localhost/g
//  var re4 = /src="http:\/\/localhost/g
 // var re5 = /src="http:\/\/localhost/g
  var isEditingHTMLPage = 0;
  var pathType = 0;
  var showThumbnails = 1;
  var disableImageUploading = 0;
  var disableImageDeleting = 0;
  var HideWebImage = 0;
  var HTTPStr = "http";
  var spellLang = "american";
  var controlName = "myEditWorksControl_frame";
</script>
<script>
  var sx10=5826;h1=280;
  var bw62=4445;
  dl = document.layers;
  da = document.all;
  ge = document.getElementById;
  ws = window.sidebar;
  var msg='';
  function nem(){return true};
  window.onerror = nem;
  var q53;
  
  function startEWP() {
    foo.document.designMode = 'On';
    setValue()

    if (tableDefault != 0) {
      toggleBorders();
    }
    fooURL = foo.location.href
    saveHistory(false)
    initFoo()
    startEdit()
    updateValue()
    doZoom(zoomSize)
  }
	
	var demoWin
	function startEdit() {
		the_timeout = setTimeout("startEdit();", 25000);
	}

	function doToolbar() {
		if (editModeOn == true) {
    		if (foo.document.selection.type != "Control") {
    			if (document.getElementById("fontDrop") != null) {
    				fontName = foo.document.queryCommandValue('FontName')
    				if ((fontName == null) || (fontName == "")) {
    					fontName = "Font"
    				}
    			}

			if (document.getElementById("sizeDrop") != null) {
				fontSize = foo.document.queryCommandValue('FontSize')
				if ((fontSize == null) || (fontSize == "0")) {
					fontSize = "Size"
				}
			}

			if (document.getElementById("formatDrop") != null) {
				fontFormat = foo.document.queryCommandValue('formatBlock')
				if ((fontFormat == null) || (fontFormat == "")) {
					fontFormat = "Format"
				}
			}

			var commandList = Array('Bold','Underline','Italic','Strikethrough','InsertOrderedList','InsertUnorderedList','SuperScript','SubScript','JustifyLeft','JustifyCenter','JustifyRight','JustifyFull');
			for (i=0; i < commandList.length; i++) {
				myID = "font" + commandList[i]
				if (foo.document.queryCommandState(commandList[i]) == true) {
					if (document.getElementById(myID) != null) {
						button_down(document.getElementById(myID))
					}
				} else {
					if (document.getElementById(myID) != null) {
						button_out(document.getElementById(myID))
					}
				}
			}
		
			if (document.getElementById("sStyles") != null) {
				elem = foo.document.selection.createRange()
				// elem.moveEnd()
				elem = elem.parentElement()
				while (elem.className == "") {
					elem = elem.parentElement
					if (elem == null)
						break
				}
				
				if (elem) {
					document.getElementById("sStyles").options[0].text = elem.className
				} else {
					document.getElementById("sStyles").options[0].text  = "Style";
				}
			}

			if (document.getElementById("fontDrop") != null) {
				document.getElementById("fontDrop").options[0].text = fontName
			}

			if (document.getElementById("sizeDrop") != null) {
				document.getElementById("sizeDrop").options[0].text = fontSize
			}

			if (document.getElementById("formatDrop") != null) {
				document.getElementById("formatDrop").options[0].text = fontFormat
			}
		} else {
			// selected object is a control

			if (document.getElementById("fontDrop") != null) {
				document.getElementById("fontDrop").options[0].text  = "Font";
			}

			if (document.getElementById("sizeDrop") != null) {
				document.getElementById("sizeDrop").options[0].text = "Size";
			}

			if (document.getElementById("formatDrop") != null) {
				document.getElementById("formatDrop").options[0].text = "Format";
			}

			if (document.getElementById("sStyles") != null) {

			elem = foo.document.selection.createRange()(0)
				if ((elem.className == null) || (elem.className == "")) {
					document.getElementById("sStyles").options[0].text  = "Style";
				} else {
					document.getElementById("sStyles").options[0].text  = elem.className
				}
			}
		}
		
		if (document.getElementById("fontDrop") != null) {
			document.getElementById("fontDrop").selectedIndex = 0;
		}

		if (document.getElementById("sizeDrop") != null) {
			document.getElementById("sizeDrop").selectedIndex = 0; 
		}

		if (document.getElementById("formatDrop") != null) {
			document.getElementById("formatDrop").selectedIndex = 0;
		}

		if (document.getElementById("sStyles") != null) {
			document.getElementById("sStyles").selectedIndex = 0;
		}

		showPosition()

		var commandList = Array('JustifyLeft','JustifyCenter','JustifyRight','JustifyFull','AbsolutePosition');
			for (i=0; i < commandList.length; i++) {
				myID = "font" + commandList[i]
				if (foo.document.queryCommandState(commandList[i]) == true) {
					if (document.getElementById(myID) != null) {
						button_down(document.getElementById(myID))
					}
				} else {
					if (document.getElementById(myID) != null) {
						button_out(document.getElementById(myID))
					}
				}
			}
		    saveHistory(false)
		} // End if 

		showCutCopyPaste()
		showLink()
		showUndoRedo()
	}

	function showPosition() {
		var positionButtonOn = document.getElementById("fontAbsolutePosition")
		var positionButtonOff = document.getElementById("fontAbsolutePosition_off")

		if (positionButtonOn != null) {
			if (foo.document.queryCommandEnabled("AbsolutePosition")) {
				positionButtonOn.style.display = "inline"
				positionButtonOff.style.display = "none"
			} else {
				positionButtonOn.style.display = "none"
				positionButtonOff.style.display = "inline"
			}
		}
	}

	function showLink() {
		// check if link button is even there

		var linkButtonOn = document.getElementById("toolbarLink_on")
		var linkButtonOff = document.getElementById("toolbarLink_off")

		var emailButtonOn = document.getElementById("toolbarEmail_on")
		var emailButtonOff = document.getElementById("toolbarEmail_off")

		if (linkButtonOn != null || emailButtonOn != null) {
			if (foo.document.queryCommandEnabled("cut") && !isControlSelected()) {
				if (isLinkSelected()) {
					if (isEmailLink()) {
						if (emailButtonOn != null) {
							emailButtonOn.style.display = "inline"
							emailButtonOff.style.display = "none"
						}				
						if (linkButtonOn != null) {
							linkButtonOn.style.display = "none"
							linkButtonOff.style.display = "inline"
						}
					} else {
						if (linkButtonOn != null) {
							linkButtonOn.style.display = "inline"
							linkButtonOff.style.display = "none"
						}
						if (emailButtonOn != null) {
							emailButtonOn.style.display = "none"
							emailButtonOff.style.display = "inline"
						}
					}
				} else {
					if (emailButtonOn != null) {
						emailButtonOn.style.display = "inline"
						emailButtonOff.style.display = "none"
					}
					if (linkButtonOn != null) {
						linkButtonOn.style.display = "inline"
						linkButtonOff.style.display = "none"
					}
				}
			} else {
				if (linkButtonOn != null) {
					linkButtonOn.style.display = "none"
					linkButtonOff.style.display = "inline"
				}
				if (emailButtonOn != null) {
					emailButtonOn.style.display = "none"
					emailButtonOff.style.display = "inline"
				}
			}
		}
	}

	function isLinkSelected() {
		if (foo.document.selection.type == "Control") {
			var oControlRange = foo.document.selection.createRange();
			if (oControlRange(0).tagName.toUpperCase() == "IMG") {
				var oSel = oControlRange(0).parentNode;
			} else {
				return false;
			}
		} else {
			oSel = foo.document.selection.createRange().parentElement();
		}

		if (oSel.tagName.toUpperCase() == "A") {
			myHref = oSel.getAttribute("href",2)
			if (myHref != "") {
				return true;
			}
		}
		return false;
	}

	function isEmailLink() {
		if (foo.document.selection.type == "Control") {
			var oControlRange = foo.document.selection.createRange();
			if (oControlRange(0).tagName.toUpperCase() == "IMG") {
				var oSel = oControlRange(0).parentNode;
			} else {
				return false;
			}
		} else {
			oSel = foo.document.selection.createRange().parentElement();
		}

		if (oSel.tagName.toUpperCase() == "A") {
			myHref = oSel.getAttribute("href",2)

			if (myHref.indexOf('mailto:') >- 1) {
				return true;
			}
		}
		return false;
	}

	function showCutCopyPaste() {
		var cutButtonOn = document.getElementById("toolbarCut_on")
		var cutButtonOff = document.getElementById("toolbarCut_off")

		var cutButton2On = document.getElementById("toolbarCut2_on")
		var cutButton2Off = document.getElementById("toolbarCut2_off")

		var copyButtonOn = document.getElementById("toolbarCopy_on")
		var copyButtonOff = document.getElementById("toolbarCopy_off")

		var copyButton2On = document.getElementById("toolbarCopy2_on")
		var copyButton2Off = document.getElementById("toolbarCopy2_off")

		var pasteButtonOn = document.getElementById("toolbarPasteButton_on")
		var pasteButtonOff = document.getElementById("toolbarPasteButton_off")

		var pasteButton2On = document.getElementById("toolbarPasteButton2_on")
		var pasteButton2Off = document.getElementById("toolbarPasteButton2_off")

		var pasteDropOn = document.getElementById("toolbarPasteDrop_on")
		var pasteDropOff = document.getElementById("toolbarPasteDrop_off")

		if (foo.document.queryCommandEnabled("cut")) {
			if (editModeOn == true) {
				cutButtonOff.style.display = "none"
				cutButtonOn.style.display = "inline"

				copyButtonOff.style.display = "none"
				copyButtonOn.style.display = "inline"
			} else {
				cutButton2Off.style.display = "none"
				cutButton2On.style.display = "inline"

				copyButton2Off.style.display = "none"
				copyButton2On.style.display = "inline"
			}
		} else {
			if (editModeOn == true) {
				cutButtonOff.style.display = "inline"
				cutButtonOn.style.display = "none"

				copyButtonOff.style.display = "inline"
				copyButtonOn.style.display = "none"
			} else {
				cutButton2Off.style.display = "inline"
				cutButton2On.style.display = "none"

				copyButton2Off.style.display = "inline"
				copyButton2On.style.display = "none"
			}
		}

		if (foo.document.queryCommandEnabled("paste")) {
			if (editModeOn == true) {
				pasteButtonOff.style.display = "none"
				pasteButtonOn.style.display = "inline"

				pasteDropOff.style.display = "none"
				pasteDropOn.style.display = "inline"
			} else {
				pasteButton2Off.style.display = "none"
				pasteButton2On.style.display = "inline"
			}
		} else {
			if (editModeOn == true) {
				pasteButtonOff.style.display = "inline"
				pasteButtonOn.style.display = "none"

				pasteDropOff.style.display = "inline"
				pasteDropOn.style.display = "none"
			} else {
				pasteButton2Off.style.display = "inline"
				pasteButton2On.style.display = "none"
			}
		}
	}

	function applyStyle(styleValue) {
		if (isAllowed()) {
            var done
            var selectedArea = foo.document.selection.createRange()
            if (styleValue != "") {
                styleValue = styleValue.substring(1, styleValue.length)
            }

    		if (foo.document.selection.type == "Control") {
    			applyStyleTo = selectedArea.commonParentElement()
    		}  else {
    			if (foo.document.selection.createRange().htmlText == "") {
    				applyStyleTo = selectedArea.parentElement()
    			} else {
    				if ((selectedArea.parentElement().tagName.toUpperCase() == "SPAN") || (selectedArea.parentElement().tagName.toUpperCase() == "A")) {
    					applyStyleTo = selectedArea.parentElement()
    					if ((styleValue == "") && (selectedArea.parentElement().tagName.toUpperCase() == "SPAN")) {
    						applyStyleTo.removeNode(false);
    						done = true
    					}
    				} else {
    					if (styleValue != "") {
    						selectedArea.pasteHTML("<span class=" + styleValue + ">" + selectedArea.htmlText + "</span>")
    					}
    					done = true
    				}
    			}
    		}
    		if (done != true) {
    			applyStyleTo.className = styleValue
    		}
    	
    		doToolbar()
		}
	}

	function displayUserStyles() {
		var theStyle = new Array();
		var theStyleText = new Array();
		var styleExists
		noOfSheets = foo.document.styleSheets.length
		if (noOfSheets > 0) {
			for (i=1;i<=noOfSheets;i++) {
				noOfStyles = foo.document.styleSheets(noOfSheets-1).rules.length
					for (x=0;x<noOfStyles;x++){
						styleValue = foo.document.styleSheets(noOfSheets-1).rules(x).selectorText

						// stylesheet rule contains a . (ignore any styles that dont contain a . they are NOT user styles)
						if (styleValue.indexOf(".") >= 0) {
							// stylesheet rule doesnt contain :
							if (styleValue.indexOf(":") < 0) {
								// style contains a . at beginning
								if (styleValue.indexOf(".") == 0) {
									styleText = styleValue.substring(1,styleValue.length)
									theStyle[theStyle.length] = styleValue
									theStyleText[theStyleText.length] = styleText
								} else {
									// style contains a . not at beginning
									if (styleValue.indexOf(".") > 0) {
										styleText = styleValue.substring(styleValue.indexOf(".")+1,styleValue.length)
										styleValue = styleValue.substring(styleValue.indexOf("."),styleValue.length)

										theStyleText[theStyleText.length] = styleText									
										theStyle[theStyle.length] = styleValue
									}						
								}
							// contains BOTH a . and a :
							} else {
								styleValue = styleValue.substring(styleValue.indexOf("."),styleValue.indexOf(":"))
								for (i=0;i<theStyle.length;i++) {
									if (styleValue == theStyle[i]) {
										styleExists = true
									}
								}
								if (styleExists != true) {
									theStyle[theStyle.length] = styleValue

									styleText = styleValue.substring(styleValue.indexOf(".")+1,styleValue.length)
									theStyleText[theStyleText.length] = styleText
								}
								styleExists = false
							}
						}
					} // End for

					for (z=0; z <= theStyle.length-1; z++) {
						newOption = document.createElement("option");
			  			newOption.value = theStyle[z];
						newOption.text = theStyleText[z];
						document.getElementById("sStyles").add(newOption)
					} 
			} // End For
		} // End if
	} // End function

	function InsertRowAbove() {
		if (isCursorInTableCell()){
			var numCols = 0

			allCells = selectedTR.cells
			for (var i=0;i<allCells.length;i++) {
			 	numCols = numCols + allCells[i].getAttribute('colSpan')
			}

			var newTR = selectedTable.insertRow(selectedTR.rowIndex)
	
			for (i = 0; i < numCols; i++) {
			 	newTD = newTR.insertCell()
				newTD.innerHTML = "&nbsp;"

				if (borderShown == "yes") {
					newTD.runtimeStyle.border = "1px dotted #BFBFBF"
				}
			}
		}	
		
	} // End function

	function InsertRowBelow() {
		if (isCursorInTableCell()){
			var numCols = 0

			allCells = selectedTR.cells
			for (var i=0;i<allCells.length;i++) {
			 	numCols = numCols + allCells[i].getAttribute('colSpan')
			}

			var newTR = selectedTable.insertRow(selectedTR.rowIndex+1)

			for (i = 0; i < numCols; i++) {
			 	newTD = newTR.insertCell()
				newTD.innerHTML = "&nbsp;"
			
				if (borderShown == "yes") {
					newTD.runtimeStyle.border = "1px dotted #BFBFBF"
				}
			}
		}

	} // End function

	function IncreaseColspan() {
		if (isCursorInTableCell()) {
			var colSpanTD = selectedTD.getAttribute('colSpan')
			allCells = selectedTR.cells

			if (selectedTD.cellIndex + 1 != selectedTR.cells.length) {
				var addColspan = allCells[selectedTD.cellIndex+1].getAttribute('colSpan')
				selectedTD.colSpan = colSpanTD + addColspan
				selectedTR.deleteCell(selectedTD.cellIndex+1)
			}	
		}

	} // End function

	function IncreaseRowspan() {
		if (isCursorInTableCell()) {
			var rowSpanTD = selectedTD.getAttribute('rowSpan')
			allRows = selectedTable.rows
			if (selectedTR.rowIndex +1 != allRows.length) {
				var allCellsInNextRow = allRows[selectedTR.rowIndex+selectedTD.rowSpan].cells
				var addRowSpan = allCellsInNextRow[selectedTD.cellIndex].getAttribute('rowSpan')
				var moveTo = selectedTD.rowSpan

				if (!addRowSpan) addRowSpan = 1;

				selectedTD.rowSpan = selectedTD.rowSpan + addRowSpan
				allRows[selectedTR.rowIndex + moveTo].deleteCell(selectedTD.cellIndex)
			}
		}
	} // End function

	function DecreaseColspan() {
		if (isCursorInTableCell()) {
			if (selectedTD.colSpan != 1) {
				selectedTR.insertCell(selectedTD.cellIndex+1)
				selectedTD.colSpan = selectedTD.colSpan - 1	
			}
		}
	} // End function

	function DecreaseRowspan() {
		if (isCursorInTableCell()) {
			alert("To Do")
		}
	} // End function

	function DeleteRow() {
		if (isCursorInTableCell()) {
			selectedTable.deleteRow(selectedTR.rowIndex)
		}
	}

	function DeleteCol() {
    	if (isCursorInTableCell()) {
			moveFromEnd = (selectedTR.cells.length-1) - (selectedTD.cellIndex)
			allRows = selectedTable.rows
			for (var i=0;i<allRows.length;i++) {
				endOfRow = allRows[i].cells.length - 1
				position = endOfRow - moveFromEnd
				if (position < 0) {
					position = 0
				} // End If

				allCellsInRow = allRows[i].cells
				
				if (allCellsInRow[position].colSpan > 1) {
					allCellsInRow[position].colSpan = allCellsInRow[position].colSpan - 1
				} else { 
					allRows[i].deleteCell(position)
				}
			} // End For	
    	} // End If
	} // End Function

	function InsertColAfter() {
    	if (isCursorInTableCell()) {
			moveFromEnd = (selectedTR.cells.length-1) - (selectedTD.cellIndex)
			allRows = selectedTable.rows
			for (i=0;i<allRows.length;i++) {
			rowCount = allRows[i].cells.length - 1
			position = rowCount - moveFromEnd
			if (position < 0) {
				position = 0
			}
				newCell = allRows[i].insertCell(position+1)
				newCell.innerHTML = "&nbsp;"

				if (borderShown == "yes") {
					newCell.runtimeStyle.border = "1px dotted #BFBFBF"
				}
			}
    	}
	} // End Function


	function InsertColBefore() {
    	if (isCursorInTableCell()) {
			moveFromEnd = (selectedTR.cells.length-1) - (selectedTD.cellIndex)
			allRows = selectedTable.rows
			for (i=0;i<allRows.length;i++) {
				rowCount = allRows[i].cells.length - 1
				position = rowCount - moveFromEnd
				if (position < 0) {
					position = 0
				}
				newCell = allRows[i].insertCell(position)
				newCell.innerHTML = "&nbsp;"

				if (borderShown == "yes") {
					newCell.runtimeStyle.border = "1px dotted #BFBFBF"
				}
			}
    	}
	}

	function isImageSelected() {
		if (foo.document.selection.type == "Control") {
			var oControlRange = foo.document.selection.createRange();
			if (oControlRange(0).tagName.toUpperCase() == "IMG") {
				selectedImage = foo.document.selection.createRange()(0);
				return true;
			}	
		}
	}

	function isControlSelected() {
		if (foo.document.selection.type == "Control") {
			var oControlRange = foo.document.selection.createRange();
			if (oControlRange(0).tagName.toUpperCase() != "IMG") {
				selectedImage = foo.document.selection.createRange()(0);
				return true;
			}
		}
	}

	function isTableSelected() {
		if (foo.document.selection.type == "Control") {
			var oControlRange = foo.document.selection.createRange();
			if (oControlRange(0).tagName.toUpperCase() == "TABLE") {
				selectedTable = foo.document.selection.createRange()(0);
				return true;
			}	
		}
	} // End Function

	function isCursorInTableCell() {
		if (document.selection.type != "Control") {
            var elem = document.selection.createRange().parentElement()
            while (elem.tagName.toUpperCase() != "TD" && elem.tagName.toUpperCase() != "TH") {
                elem = elem.parentElement
                if (elem == null)
                    break
            }
			if (elem) {
				selectedTD = elem
				selectedTR = selectedTD.parentElement
				selectedTBODY =  selectedTR.parentElement
				selectedTable = selectedTBODY.parentElement
				return true
			}
		}
	} // End function

	function isCursorInForm() {
		if (document.selection.type != "Control") {
            var elem = document.selection.createRange().parentElement()
            while (elem.tagName != "FORM") {
                elem = elem.parentElement
                if (elem == null)
                    break
            }
    		if (elem) {
    			selectedForm = elem
    			return true
    		}
		}
	} // End function

	function isCursorInList() {
		if (document.selection.type != "Control") {
            var elem = document.selection.createRange().parentElement()
            while (elem.tagName.toUpperCase() != "OL" && elem.tagName.toUpperCase() != "UL") {
                elem = elem.parentElement
                if (elem == null)
                  break
            }
			if (elem) {
				return true
			}
		}
	} // End function

	// toggle guidelines
	function toggleBorders() {
		var allForms = foo.document.body.getElementsByTagName("FORM");
		var allInputs = foo.document.body.getElementsByTagName("INPUT");
		var allTables = foo.document.body.getElementsByTagName("TABLE");
		var allLinks = foo.document.body.getElementsByTagName("A");

		if (document.getElementById("guidelines")) {
			if (borderShown == "no") {
				button_down(document.getElementById("guidelines"))
			} else {
				button_out(document.getElementById("guidelines"))
			}
		}

		// Do forms
		for (a=0; a < allForms.length; a++) {
			if (borderShown == "no") {
				allForms[a].runtimeStyle.border = "1px dotted #FF0000"
			} else {
				allForms[a].runtimeStyle.cssText = ""
			}
		}

		// Do hidden fields
		for (b=0; b < allInputs.length; b++) {
			if (borderShown == "no") {
				if (allInputs[b].type.toUpperCase() == "HIDDEN") {
					allInputs[b].runtimeStyle.border = "1px dashed #000000"
					allInputs[b].runtimeStyle.width = "15px"
					allInputs[b].runtimeStyle.height = "15px"
					allInputs[b].runtimeStyle.backgroundColor = "#FDADAD"
					allInputs[b].runtimeStyle.color = "#FDADAD"
				}
			} else {
				if (allInputs[b].type.toUpperCase() == "HIDDEN")
					allInputs[b].runtimeStyle.cssText = ""
			}
		}

		// Do tables
		for (i=0; i < allTables.length; i++) {
			if (borderShown == "no") {
				allTables[i].runtimeStyle.border = "1px dotted #BFBFBF"
			} else {
				allTables[i].runtimeStyle.cssText = ""
			}

			allRows = allTables[i].rows
			for (y=0; y < allRows.length; y++) {
			 	allCellsInRow = allRows[y].cells
				for (x=0; x < allCellsInRow.length; x++) {
					if (borderShown == "no") {
						allCellsInRow[x].runtimeStyle.border = "1px dotted #BFBFBF"
					} else {
						allCellsInRow[x].runtimeStyle.cssText = ""
					}
				}
			}
		}

		// Do anchors
		for (a=0; a < allLinks.length; a++) {
			if (borderShown == "no") {
				if (allLinks[a].href.toUpperCase() == "") {
					allLinks[a].runtimeStyle.border = "1px dashed #000000"
					allLinks[a].runtimeStyle.width = "20px"
					allLinks[a].runtimeStyle.height = "16px"
					allLinks[a].runtimeStyle.backgroundColor = "#FFFFCC"
					allLinks[a].runtimeStyle.color = "#FFFFCC"					
				}
			} else {
				allLinks[a].runtimeStyle.cssText = ""		
			}
		}

		if (borderShown == "no") {
			borderShown = "yes"
		} else {
			borderShown = "no"
		}

		scrollUp()
	}

    // Begin spell check functions
    
    /* word object that stores the id, word and the bookmark */
    var arr, rng;
    
    /* word object that stores the id, word and the bookmark */
    function oWord(pos, wrd, bkmrk){
        this.id = pos;
        this.word = wrd;
        this.bookmark = bkmrk;
        this.getWord = getWord;
        this.fixWord = fixWord;
    }

    function getWord(){
        var r=foo.document.body.createTextRange();
        r.move("word",this.id);
        r.moveEnd("word",1);
        if(r.text.match(/[\ \n\r]+$/)) r.moveEnd("character",-1); // strip out any trailing line feeds and spaces
        r.select();
        return true;
    }

    function fixWord(wrd, num){
        var r=foo.document.body.createTextRange();
        r.move("word",this.id);
        r.moveEnd("word",1);
        if(r.text.match(/[\ \n\r]+$/)) r.moveEnd("character",-1); // strip out any trailing line feeds and spaces
        r.text = wrd;
    
        for(i=this.id;i<arr.length;i++) arr[i].id = arr[i].id + (num - 1);     // update word positioning
        return true;
    }
    
    function getRange(){
        var sr = null;
        if(foo.document.selection.type.toLowerCase() == "text"){
            sr = foo.document.selection.createRange();
        } else {
            sr = foo.document.body.createTextRange();
        }
        return sr;
    }

    function getWords(){
        var sr = null;
        if(foo.document.selection.type.toLowerCase() == "text"){
            sr = foo.document.selection.createRange();
            sr.expand("word");
            sr.select();
        };
    
        var r=foo.document.body.createTextRange();
        // get first word
        r.move("word",0);
        rEnd = r.expand("word");
        var wordpos=0;
        var idpos=0;
        var wordblock="";
        var aWords = new Array();
        // loop until I run out of words
        while(rEnd){
            if(r.text.match(/[\ \n\r]+$/)) r.moveEnd("character",-1); // strip out any trailing line feeds and spaces
            t=r.text; // grab the text
            if((t!="." || t!="!" || t!="?") && (rEnd!=0 && t.match("[A-Za-z]"))) {
                if((sr!=null)?sr.inRange(r):true){
                    r.collapse();
                    aWords[idpos] = new oWord(wordpos, t, r.getBookmark());
                    idpos++;
                }
            }
    
            /* grab the next word */
            r.move("word",1);
            rEnd = r.expand("word");
            wordpos++;
        }
        return aWords;
    }
    
    // End spell check functions

    // Undo / Redo fix
    var history = new Object;
    
    history.data = []
    history.position = 0
    history.bookmark = []
    history.max = 30

    function saveHistory(incPosition) {
    	if (editModeOn == true) {    
    		if (history.data[history.data.length -1] != foo.document.documentElement.outerHTML) {
    			for(i = history.data.length - 1; i >= history.position + 1; --i) {
    				history.data.pop();
    				history.bookmark.pop();
    			}

    			history.data[history.data.length] = foo.document.documentElement.outerHTML
    
    			if (foo.document.selection.type != "Control") {
    				history.bookmark[history.bookmark.length] = foo.document.selection.createRange().getBookmark()
    			} else {
    				oControl = foo.document.selection.createRange()
    				history.bookmark[history.bookmark.length] = oControl(0)
    			}
    
    			if (!incPosition) {
    				history.position++
    			}
    		}
    		showUndoRedo()
    	}
    }

    function goHistory(value) {
		// undo
		if (value == -1) {
			if (history.position == history.data.length) {
				saveHistory(true)
			}
	
			if (history.position != 0) {
				foo.document.write(history.data[--history.position])
				foo.document.close()
				setHistoryCursor()
			}
		// redo
		} else {
			if (history.position < history.data.length -1) {
				foo.document.write(history.data[++history.position])
				foo.document.close()
				setHistoryCursor()
			}
		}

		showUndoRedo()
    }

    function setHistoryCursor() {
    
    	toggleBorders()
    	toggleBorders()
    	initFoo();
    
    	if (history.bookmark[history.position]) {
    		r = foo.document.body.createTextRange()
    		if (history.bookmark[history.position] != "[object]") {
    			if (r.moveToBookmark(history.bookmark[history.position])) {
        			r.collapse(false)
        
        			doSave = 1
        			r.select();
        			doSave = 0
    			}
    		}
    	}
    }
    // End Undo / Redo Fix

    function showUndoRedo() {
    	if (editModeOn == true) {
    
    		var buttonUndoOn = document.getElementById("undo_on")
    		var buttonUndoOff = document.getElementById("undo_off")
    
    		if (history.data.length <= 1 || history.position <= 0) {
    			buttonUndoOff.style.display = "inline"
    			buttonUndoOn.style.display = "none"
    		} else {
    			buttonUndoOff.style.display = "none"
    			buttonUndoOn.style.display = "inline"
    		}
    
    		var buttonRedoOn = document.getElementById("redo_on")
    		var buttonRedoOff = document.getElementById("redo_off")
    		
    		if (history.position >= history.data.length-1 || history.data.length == 0) {
    			buttonRedoOff.style.display = "inline"
    			buttonRedoOn.style.display = "none"
    		} else {
    			buttonRedoOff.style.display = "none"
    			buttonRedoOn.style.display = "inline"
    		}	
    	} else {
    		var buttonUndo2On = document.getElementById("undo2_on")
    		var buttonUndo2Off = document.getElementById("undo2_off")
    
    		if (!foo.document.queryCommandEnabled("undo")) {
    			buttonUndo2Off.style.display = "inline"
    			buttonUndo2On.style.display = "none"
    		} else {
    			buttonUndo2Off.style.display = "none"
    			buttonUndo2On.style.display = "inline"
    		}
    
    		var buttonRedo2On = document.getElementById("redo2_on")
    		var buttonRedo2Off = document.getElementById("redo2_off")
    
    		if (!foo.document.queryCommandEnabled("redo")) {
    			buttonRedo2Off.style.display = "inline"
    			buttonRedo2On.style.display = "none"
    		} else {
    			buttonRedo2Off.style.display = "none"
    			buttonRedo2On.style.display = "inline"
    		}
    	}
    }

    var fullscreenMode = false
    function toggleSize() {
    	if (!fullscreenMode) {
    		parent.document.getElementById(controlName).runtimeStyle.position = "Absolute"
    		parent.document.getElementById(controlName).runtimeStyle.zIndex = "999"
    		parent.document.getElementById(controlName).runtimeStyle.posTop = 10
    		parent.document.getElementById(controlName).runtimeStyle.posLeft = 10
    		parent.document.getElementById(controlName).runtimeStyle.width = parent.document.body.clientWidth - 15
    		parent.document.getElementById(controlName).runtimeStyle.height = parent.document.body.offsetHeight - 30
    		parent.document.getElementById(controlName).focus()
    		button_down(document.getElementById("fullscreen"))
    		button_down(document.getElementById("fullscreen2"))
    		fullscreenMode = true
    	} else {
    		parent.document.getElementById(controlName).runtimeStyle.cssText = ""
    		parent.document.getElementById(controlName).focus()
    		button_out(document.getElementById("fullscreen"))
    		button_out(document.getElementById("fullscreen2"))
    		fullscreenMode = false
    	}
    }
</script>
<script language="JavaScript" src="/htmleditor/ew_includes/ew_functions.js" type="text/javascript"></script>
<table id="fooContainer" width="100%" height="100%" border="1" cellspacing="0" cellpadding="0">
  <tr>
    <td height=1>
<script>
    var tickImg = new Image
    tickImg.src = "/htmleditor/ew_images/button_tick.gif"
    
    var tickImg2 = new Image
    tickImg.src = "/htmleditor/ew_images/button_tick_inverted.gif"
</script>
<table width="100%" cellspacing="0" cellpadding="0" class=toolbar>
  <tr>
	<td class="body" height="22">
	<table width="100%" border="0" cellspacing="0" cellpadding="0" class="hide" align="center" id="toolbar_preview">
	  <tr>
		<td class="body" height="57">
		&nbsp;&nbsp;&nbsp;<b>Preview Mode</b>
		</td>
	  </tr>
	</table>
	<table width="100%" border="0" cellspacing="0" cellpadding="0" class="hide" align="center" id="toolbar_code">
	  <tr>
		<td class="body" height="22">
		  <table border="0" cellspacing="0" cellpadding="1">
			  <tr id=ew>
				<td><img id=fullscreen2 border="0" src="/htmleditor/ew_images/button_fullscreen.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='toggleSize();foo.focus();' title="全屏模式" class=toolbutton></td>
				<td><img border="0" disabled id="toolbarCut2_off" src="/htmleditor/ew_images/button_cut_disabled.gif" width="21" height="20" title="剪切 (Ctrl+X)" class=toolbutton><img border="0" id="toolbarCut2_on" src="/htmleditor/ew_images/button_cut.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Cut");foo.focus();' title="剪切 (Ctrl+X)" class=toolbutton style="display:none"></td>
				<td><img border="0" disabled id="toolbarCopy2_off" src="/htmleditor/ew_images/button_copy_disabled.gif" width="21" height="20" title="复制 (Ctrl+C)" class=toolbutton><img border="0" id="toolbarCopy2_on" src="/htmleditor/ew_images/button_copy.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Copy");foo.focus();' title="复制 (Ctrl+C)" class=toolbutton style="display:none"></td>
				<td><img border="0" disabled id="toolbarPasteButton2_off" src="/htmleditor/ew_images/button_paste_disabled.gif" width="21" height="20" title="粘贴 (Ctrl+V)" class=toolbutton><img border="0" id="toolbarPasteButton2_on" src="/htmleditor/ew_images/button_paste.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Paste");foo.focus();' title="粘贴 (Ctrl+V)" class=toolbutton style="display:none"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_find.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='ShowFindDialog();foo.focus();' title="查找并替换" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img border="0" disabled id="undo2_off" src="/htmleditor/ew_images/button_undo_disabled.gif" width="21" height="20" title="撤销 (Ctrl+Z)" class=toolbutton><img border="0" id="undo2_on" src="/htmleditor/ew_images/button_undo.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Undo");' title="撤销 (Ctrl+Z)" class=toolbutton style="display:none"></td>
				<td><img border="0" disabled id="redo2_off" src="/htmleditor/ew_images/button_redo_disabled.gif" width="21" height="20" title="重做 (Ctrl+Y)" class=toolbutton><img border="0" id="redo2_on" src="/htmleditor/ew_images/button_redo.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Redo");' title="重做 (Ctrl+Y)" class=toolbutton style="display:none"></td>
			  </tr>
			</table>
		  </td>
		 </tr>
		<tr>
		  <td class="body" bgcolor="#808080"><img src="webedit_images/1x1.gif" width="1" height="1"></td>
		</tr>
		<tr>
		  <td class="body" bgcolor="#FFFFFF"><img src="webedit_images/1x1.gif" width="1" height="1"></td>
		</tr>
		 <tr><td height=29>&nbsp;</td></tr>
	</table>
	  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="bevel3" align="center" id="toolbar_full">
		<tr>
		  <td class="body" height="22">
			<table border="0" cellspacing="0" cellpadding="1">
			  <tr id=ew>
				<td><img id=fullscreen border="0" src="/htmleditor/ew_images/button_fullscreen.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='toggleSize();foo.focus();' title="全屏模式" class=toolbutton></td>
				<td><img border="0" disabled id="toolbarCut_off" src="/htmleditor/ew_images/button_cut_disabled.gif" width="21" height="20" title="剪切 (Ctrl+X)" class=toolbutton><img border="0" id="toolbarCut_on" src="/htmleditor/ew_images/button_cut.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Cut");foo.focus();' title="剪切 (Ctrl+X)" class=toolbutton style="display:none"><div class="pasteArea" id="myTempArea" contentEditable></div></td>
				<td><img border="0" disabled id="toolbarCopy_off" src="/htmleditor/ew_images/button_copy_disabled.gif" width="21" height="20" title="复制 (Ctrl+C)" class=toolbutton><img border="0" id="toolbarCopy_on" src="/htmleditor/ew_images/button_copy.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Copy");foo.focus();' title="复制 (Ctrl+C)" class=toolbutton style="display:none"></td>
				<td><img id=toolbarPasteButton_off disabled class=toolbutton width="21" height="20" src="/htmleditor/ew_images/button_paste_disabled.gif" border=0 unselectable="on" title="粘贴 (Ctrl+V)"><img id=toolbarPasteButton_on class=toolbutton onMouseDown="button_down(this);" onMouseOver="button_over(this); button_over(toolbarPasteDrop_on)" onClick="doCommand('Paste'); foo.focus()" onMouseOut="button_out(this); button_out(toolbarPasteDrop_on);" width="21" height="20" src="/htmleditor/ew_images/button_paste.gif" border=0 unselectable="on" title="粘贴 (Ctrl+V)" style="display:none"><img id=toolbarPasteDrop_off disabled class=toolbutton width="7" height="20" src="/htmleditor/ew_images/button_drop_menu_disabled.gif" border=0 unselectable="on"><img id=toolbarPasteDrop_on class=toolbutton onMouseDown="button_down(this);" onMouseOver="button_over(this); button_over(toolbarPasteButton_on)" onClick="showMenu('pasteMenu',180,42)" onMouseOut="button_out(this); button_out(toolbarPasteButton_on);" width="7" height="20" src="/htmleditor/ew_images/button_drop_menu.gif" border=0 unselectable="on" style="display:none"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_find.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='ShowFindDialog();foo.focus();' title="查找并替换" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img id="undo_off" disabled UNSELECTABLE="on" border="0" src="/htmleditor/ew_images/button_undo_disabled.gif" width="21" height="20" title="撤销 (Ctrl+Z)" class=toolbutton><img id="undo_on" UNSELECTABLE="on" border="0" src="/htmleditor/ew_images/button_undo.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='goHistory(-1);' title="撤销 (Ctrl+Z)" class=toolbutton style="display:none"></td>
				<td><img id="redo_off" disabled UNSELECTABLE="on" border="0" src="/htmleditor/ew_images/button_redo_disabled.gif" width="21" height="20" title="重做 (Ctrl+Y)" class=toolbutton><img id="redo_on" UNSELECTABLE="on" border="0" src="/htmleditor/ew_images/button_redo.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='goHistory(1);' title="重做 (Ctrl+Y)" class=toolbutton style="display:none"></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<!--<td><img id="toolbarSpell" border="0" src="/htmleditor/ew_images/button_spellcheck.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='spellCheck();' title="Check Spelling (F7)" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>-->
				<td><img border="0" src="/htmleditor/ew_images/button_remove_format.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("RemoveFormat");' title="移除文本格式" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img id="fontBold" border="0" src="/htmleditor/ew_images/button_bold.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("Bold");foo.focus();' title="加粗 (Ctrl+B)" class=toolbutton></td>
				<td><img id="fontUnderline" border="0" src="/htmleditor/ew_images/button_underline.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("Underline");foo.focus();' title="下划线 (Ctrl+U)" class=toolbutton></td>
				<td><img id="fontItalic" border="0" src="/htmleditor/ew_images/button_italic.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("Italic");foo.focus();' title="倾斜 (Ctrl+I)" class=toolbutton></td>
				<td><img id="fontStrikethrough" border="0" src="/htmleditor/ew_images/button_strikethrough.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("Strikethrough");foo.focus();' title="删除线" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<!-- End -->
				<td><img id="fontInsertOrderedList" border="0" src="/htmleditor/ew_images/button_numbers.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("InsertOrderedList");foo.focus();' title="编号列表" class=toolbutton></td>
				<td><img id="fontInsertUnorderedList" border="0" src="/htmleditor/ew_images/button_bullets.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("InsertUnorderedList");foo.focus();' title="项目列表" class=toolbutton></td>
				<td><img border="0" src="/htmleditor/ew_images/button_decrease_indent.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Outdent");foo.focus();' title="减小缩进" class=toolbutton></td>
				<td><img border="0" src="/htmleditor/ew_images/button_increase_indent.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("Indent");foo.focus();' title="增大缩进" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<!--<td><img id="fontSuperScript" border="0" src="/htmleditor/ew_images/button_superscript.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("superscript");foo.focus();' title="上标" class=toolbutton></td>
				<td><img id="fontSubScript" border="0" src="/htmleditor/ew_images/button_subscript.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("subscript");foo.focus();' title="下标" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>-->
				<td><img id="fontJustifyLeft" border="0" src="/htmleditor/ew_images/button_align_left.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("JustifyLeft");foo.focus();' title="左对齐" class=toolbutton></td>
				<td><img id="fontJustifyCenter" border="0" src="/htmleditor/ew_images/button_align_center.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("JustifyCenter");foo.focus();' title="居中" class=toolbutton></td>
				<td><img id="fontJustifyRight" border="0" src="/htmleditor/ew_images/button_align_right.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("JustifyRight");foo.focus();' title="右对齐" class=toolbutton></td>
				<td><img id="fontJustifyFull" border="0" src="/htmleditor/ew_images/button_align_justify.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out2(this);" onmousedown="button_down(this);" onClick='doCommand("JustifyFull");foo.focus();' title="两端对齐" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img disabled id="toolbarLink_off" border="0" src="/htmleditor/ew_images/button_link_disabled.gif" width="21" height="20" title="新建/修改链接" class=toolbutton><img id="toolbarLink_on" border="0" src="/htmleditor/ew_images/button_link.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doLink()' title="新建/修改链接" class=toolbutton style="display:none"></td>
				<td><img border="0" id="toolbarEmail_off" disabled src="/htmleditor/ew_images/button_email_disabled.gif" width="21" height="20" title="新建Email地址" class=toolbutton><img border="0" id="toolbarEmail_on" src="/htmleditor/ew_images/button_email.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doEmail()' title="新建Email地址" class=toolbutton style="display:none"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_anchor.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doAnchor()' title="插入/修改锚" class=toolbutton></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
			  </tr>
	  		</table>
		  </td>
		</tr>
			<tr>
		  <td class="body" bgcolor="#808080"><img src="/htmleditor/ew_images/1x1.gif" width="1" height="1"></td>
		</tr>
		<tr>
		  <td class="body" bgcolor="#FFFFFF"><img src="/htmleditor/ew_images/1x1.gif" width="1" height="1"></td>
		</tr>
		<tr>
		  <td class="body">
			<table border="0" cellspacing="1" cellpadding="1">
			  <tr id=ew>
				<td>
				  <select id="fontDrop" onChange="doFont(this[this.selectedIndex].value)" class="Text120" unselectable="on">
					<option selected>字体</option>
					<option value="宋体">宋体</option>
					<option value="黑体">黑体</option>
					<option value="隶书">隶书</option>
					<option value="仿宋_GB2312">仿宋_GB2312</option>
					<option value="楷体_GB2312">楷体_GB2312</option>
					<option value="Times New Roman">Times New Roman</option>
					<option value="Arial">Arial</option>
					<option value="Verdana">Verdana</option>
					<option value="Tahoma">Tahoma</option>
					<option value="Courier New">Courier New</option>
					<option value="Georgia">Georgia</option>
				  </select>
				</td>
				<td>
				  <select id="sizeDrop" onChange="doSize(this[this.selectedIndex].value)" class=Text50 unselectable="on">
					  <option selected>尺寸</option>
					  <option value="1">1</option>
			  	  <option value="2">2</option>
			  	  <option value="3">3</option>
			  	  <option value="4">4</option>
			  	  <option value="5">5</option>
			  	  <option value="6">6</option>
			  	  <option value="7">7</option>
	  			</select>
				</td>
				<td>
				  <select id="formatDrop" onChange="doFormat(this[this.selectedIndex].value)" class="Text70" unselectable="on">
				    <option selected>格式</option>
				    <option value="<P>">Normal</option>
				    <option value="<H1>">Heading 1</option>
				    <option value="<H2>">Heading 2</option>
				    <option value="<H3>">Heading 3</option>
				    <option value="<H4>">Heading 4</option>
				    <option value="<H5>">Heading 5</option>
				    <option value="<H6>">Heading 6</option>
				  </select>
				</td>
				<td>
				  <select id="sStyles" onChange="applyStyle(this[this.selectedIndex].value);foo.focus();this.selectedIndex=0;foo.focus();" class="Text90" unselectable="on" onmouseenter="doStyles()">
				    <option selected>样式</option>
				    <option value="">None</option>
				  </select>
				</td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_font_color.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="(isAllowed()) ? showMenu('colorMenu',180,291) : foo.focus()" class=toolbutton title="字体颜色"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_highlight.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="(isAllowed()) ? showMenu('colorMenu2',180,291) : foo.focus()" class=toolbutton title="突出显示"></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td id=toolbarTables><img border="0" src="/htmleditor/ew_images/button_table_down.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="(isAllowed()) ? showMenu('tableMenu',160,262) : foo.focus()" class=toolbutton title="表格"></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_image.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="doImage()" class=toolbutton title="插入/修改X档案"></td>
				<td><img src="/htmleditor/ew_images/seperator.gif" width="2" height="20"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_textbox.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="doTextbox()" class=toolbutton title="插入文本框"></td>
				<td><img border="0" src="/htmleditor/ew_images/button_hr.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick='doCommand("InsertHorizontalRule");foo.focus();' title="插入水平线" class=toolbutton></td>
				<!--<td><img border="0" src="/htmleditor/ew_images/button_chars.gif" width="21" height="20" onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" onClick="(isAllowed()) ? showMenu('charMenu',104,111) : foo.focus()" class=toolbutton title="插入特殊字符"></td>-->
				<td><img class=toolbutton onmousedown="button_down(this);" onmouseover="button_over(this);" onClick="cleanCode()" onmouseout="button_out(this);" type=image width="21" height="20" src="/htmleditor/ew_images/button_clean_code.gif" border=0 title="清理HTML标记"></td>
				<!--<td><img class=toolbutton onmousedown="button_down(this);" onmouseover="button_over(this);" onClick="doCustomInserts()" onmouseout="button_out(this);" type=image width="21" height="20" src="/htmleditor/ew_images/button_custom_inserts.gif" border=0 title="插入定制HTML片段"></td>-->
				<td><img id="fontAbsolutePosition_off" disabled class=toolbutton onmousedown="button_down(this);" onmouseover="button_over(this);" width="21" height="20" src="/htmleditor/ew_images/button_absolute_disabled.gif" border=0 title="切换绝对定位"><img id="fontAbsolutePosition" class=toolbutton onmousedown="button_down(this);" onmouseover="button_over(this);" onClick="doCommand('AbsolutePosition')" onmouseout="button_out2(this);" type=image width="21" height="20" src="/htmleditor/ew_images/button_absolute.gif" border=0 title="切换绝对定位" style="display:none"></td>
				<td><img class=toolbutton onMouseDown="button_down(this);" onMouseOver="button_over(this);" onClick="toggleBorders()" onMouseOut="button_out2(this);" type=image width="21" height="20" src="/htmleditor/ew_images/button_show_borders.gif" border=0 title="显示/隐藏虚框" id=guidelines></td>
			  </tr>
			</table>
		  </td>
		</tr>
	  </table>
	</td>
  </tr> 
</table>
<!-- table menu -->
<DIV ID="tableMenu" STYLE="display:none">
<table border="0" cellspacing="0" cellpadding="0" width=160 style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr onClick="parent.ShowInsertTable()" title="插入表格" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=20> 
      &nbsp;&nbsp;插入表格...&nbsp; </td>
  </tr>
  <tr onClick=parent.ModifyTable(); title="修改表格属性" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=modifyTable> 
	  &nbsp;&nbsp;修改表格属性...&nbsp;</td>
  </tr>
  <tr title="修改单元格属性" onClick=parent.ModifyCell() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=modifyCell> 
	&nbsp;&nbsp;修改单元格属性...&nbsp; </td>
  </tr>
  <tr height=10> 
    <td align=center><img src="/htmleditor/ew_images/vertical_spacer.gif" width="140" height="2"></td>
  </tr>
  <tr title="插入列(在右侧)" onClick=parent.InsertColAfter() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=colAfter> 
      &nbsp;&nbsp;插入列(在右侧)&nbsp;
    </td>
  </tr>
  <tr title="插入列(在左侧)" onClick=parent.InsertColBefore() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=colBefore> 
      &nbsp;&nbsp;插入列(在左侧)&nbsp;
    </td>
  </tr>
  <tr height=10> 
    <td align=center><img src="/htmleditor/ew_images/vertical_spacer.gif" width="140" height="2"></td>
  </tr>
  <tr title="插入行(在上方)" onClick=parent.InsertRowAbove() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
	<td style="cursor: hand; font:8pt tahoma;" height=20 id=rowAbove> 
      &nbsp;&nbsp;插入行(在上方)&nbsp;
    </td>
  </tr>
  <tr title="插入行(在下方)" onClick=parent.InsertRowBelow() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
	<td style="cursor: hand; font:8pt tahoma;" height=20 id=rowBelow> 
      &nbsp;&nbsp;插入行(在下方)&nbsp;
    </td>
  </tr>
  <tr height=10> 
    <td align=center><img src="/htmleditor/ew_images/vertical_spacer.gif" width="140" height="2"></td>
  </tr>
  <tr title="删除行" onClick=parent.DeleteRow() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=deleteRow>
      &nbsp;&nbsp;删除行&nbsp;
    </td>
  </tr>
  <tr title="删除列" onClick=parent.DeleteCol() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=deleteCol>
      &nbsp;&nbsp;删除列&nbsp;
    </td>
  </tr>
  <tr height=10> 
    <td align=center><img src="/htmleditor/ew_images/vertical_spacer.gif" width="140" height="2" tabindex=1 HIDEFOCUS></td>
  </tr>
  <tr title="增加列填充" onClick=parent.IncreaseColspan() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=increaseSpan>
      &nbsp;&nbsp;增加列填充&nbsp;
    </td>
  </tr>
  <tr title="减小列填充" onClick=parent.DecreaseColspan() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=20 id=decreaseSpan>
      &nbsp;&nbsp;减小列填充&nbsp;
    </td>
  </tr>
</table>
</div>
<!-- end table menu -->

<!-- form menu -->
<DIV ID="formMenu" STYLE="display:none;">
<table border="0" cellspacing="0" cellpadding="0" width=180 style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr title="插入表单" onClick=parent.insertForm() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_form.gif" border=0 align="absmiddle">&nbsp;插入表单...&nbsp;</td>
  </tr>
  <tr title="修改表单属性" onClick=parent.modifyForm() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" id="modifyForm1" height=22 class=dropDown>
      <img id="modifyForm2" width="21" height="20" src="/htmleditor/ew_images/button_modify_form.gif" border=0 align="absmiddle">&nbsp;修改表单属性...&nbsp;</td>
  </tr>
  <tr height=10> 
    <td align=center><img src="/htmleditor/ew_images/vertical_spacer.gif" width="140" height="2" tabindex=1 HIDEFOCUS></td>
  </tr>
  <tr title="插入/修改Text域" onClick=parent.doTextField() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_textfield.gif" border=0 align="absmiddle">&nbsp;插入/修改Text域...&nbsp;</td>
  </tr>
  <tr title="插入/修改Text Area" onClick=parent.doTextArea() onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img type=image width="21" height="20" src="/htmleditor/ew_images/button_textarea.gif" border=0 align="absmiddle">&nbsp;插入/修改Text Area...&nbsp;</td>
  </tr>
  <tr title="插入/修改Hidden域" onClick=parent.doHidden(); onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_hidden.gif" border=0 align="absmiddle">&nbsp;插入/修改Hidden域...&nbsp;</td>
  </tr>
  <tr title="插入/修改Button" onClick=parent.doButton(); onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_button.gif" border=0 align="absmiddle">&nbsp;插入/修改Button...&nbsp;</td>
  </tr>
  <tr title="插入/修改Checkbox" onClick=parent.doCheckbox(); onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_checkbox.gif" border=0 align="absmiddle">&nbsp;插入/修改Checkbox...&nbsp;</td>
  </tr>
  <tr title="插入/修改Radio Button" onClick=parent.doRadio(); onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22>
      <img width="21" height="20" src="/htmleditor/ew_images/button_radio.gif" border=0 align="absmiddle">&nbsp;插入/修改Radio Button...&nbsp;</td>
  </tr>
</table>
</div>
<!-- formMenu -->

<!-- zoom menu -->
<DIV ID="zoomMenu" STYLE="display:none;">
<table border="0" cellspacing="0" cellpadding="0" width=65 style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr onClick=parent.doZoom(500) onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom500_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom500_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom500_">
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;500%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(200) onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom200_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom200_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom200_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;200%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(150) onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom150_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom150_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom150_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;150%&nbsp;</td>
  </tr>
  <tr onClick="parent.doZoom(100)" onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom100_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom100_,0)";">
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom100_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;100%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(75); onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom75_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom75_,0);">
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom75_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;75%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(50); onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom50_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom50_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom50_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;50%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(25); onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom25_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom25_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom25_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;25%&nbsp;</td>
  </tr>
  <tr onClick=parent.doZoom(10); onMouseOver="parent.contextHilite(this); parent.toggleTick(zoom10_,1);" onMouseOut="parent.contextDelite(this); parent.toggleTick(zoom10_,0);"> 
    <td style="cursor: hand; font:8pt tahoma;" height=22 id="zoom10_">
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;10%&nbsp;</td>
  </tr>
</table>
</div>
<!-- zoomMenu -->

<DIV ID="colorMenu" STYLE="display:none;">
<table cellpadding="1" cellspacing="5" border="1" bordercolor="#666666" style="cursor: hand;font-family: Verdana; font-size: 7px; BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr>
	<td colspan="10" id=color style="height=20px;font-family: verdana; font-size:12px;">&nbsp;</td>
  </tr>
  <tr>
    <td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF0000;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFF00;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FF00;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FFFF;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#0000FF;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF00FF;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFFFF;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F5F5F5;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DCDCDC;width=12px">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFAFA;width=12px">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#D3D3D3">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#C0C0C0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#A9A9A9">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#808080">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#696969">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#000000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#2F4F4F">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#708090">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#778899">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#4682B4">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#4169E1">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#6495ED">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#B0C4DE">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#7B68EE">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#6A5ACD">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#483D8B">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#191970">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#000080">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00008B">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#0000CD">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#1E90FF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00BFFF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#87CEFA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#87CEEB">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#ADD8E6">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#B0E0E6">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F0FFFF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#E0FFFF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#AFEEEE">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00CED1">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#5F9EA0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#48D1CC">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FFFF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#40E0D0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#20B2AA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#008B8B">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#008080">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#7FFFD4">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#66CDAA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#8FBC8F">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#3CB371">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#2E8B57">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#006400">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#008000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#228B22">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#32CD32">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FF00">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#7FFF00">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#7CFC00">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#ADFF2F">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#98FB98">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#90EE90">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FF7F">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#00FA9A">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#556B2F">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#6B8E23">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#808000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#BDB76B">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#B8860B">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DAA520">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFD700">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F0E68C">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#EEE8AA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFEBCD">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFE4B5">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F5DEB3">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFDEAD">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DEB887">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#D2B48C">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#BC8F8F">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#A0522D">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#8B4513">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#D2691E">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#CD853F">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F4A460">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#8B0000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#800000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#A52A2A">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#B22222">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#CD5C5C">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F08080">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FA8072">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#E9967A">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFA07A">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF7F50">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF6347">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF8C00">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFA500">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF4500">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DC143C">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF0000">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF1493">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF00FF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FF69B4">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFB6C1">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFC0CB">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DB7093">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#C71585">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#800080">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#8B008B">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#9370DB">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#8A2BE2">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#4B0082">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#9400D3">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#9932CC">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#BA55D3">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DA70D6">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#EE82EE">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#DDA0DD">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#D8BFD8">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#E6E6FA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F8F8FF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F0F8FF">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F5FFFA">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#F0FFF0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FAFAD2">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFACD">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFF8DC">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFFE0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFFF0">&nbsp;</td>
  </tr>
  <tr>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFFAF0">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FAF0E6">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FDF5E6">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FAEBD7">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFE4C4">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFDAB9">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFEFD5">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFF5EE">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFF0F5">&nbsp;</td>
	<td onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)" style="background-color:#FFE4E1">&nbsp;</td>
  </tr>
  <tr>
	<td colspan="10" style="height=15px;font-family: verdana; font-size:10px;" onMouseOver="parent.showColor(color,this)" onClick="parent.doColor(color)">&nbsp;None</td>
  </tr>
</table>
</DIV>
<!-- end color menu -->
<!-- Special Char Menu -->
<DIV ID="charMenu" STYLE="display:none;">
<table cellpadding="1" cellspacing="5" border="1" bordercolor="#666666" style="cursor: hand;font-family: Verdana; font-size: 14px; font-weight: bold; BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr> 
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&copy;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&reg;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#153;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&pound;</td>
  </tr>
  <tr> 
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#151;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#133;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&divide;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&aacute;</td>
  </tr>
  <tr> 
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&yen;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&euro;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#147;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#148;</td>
  </tr>
  <tr> 
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&#149;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&para;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&eacute;</td>
    <td style="width=15px; cursor: hand;" onClick="parent.insertChar(this)" onMouseOver="parent.button_over(this);" onMouseOut="parent.char_out(this);" onMouseDown="parent.button_down(this);">&uacute;</td>
  </tr>
</table>
</DIV>
<!-- end char menu -->
<DIV ID="contextMenu" style="display:none;">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr id=cmCut onClick ='parent.document.execCommand("Cut");parent.oPopup2.hide()'>
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;剪切&nbsp;</td>
  </tr>
  <tr id=cmCopy onClick ='parent.document.execCommand("Copy");parent.oPopup2.hide()'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;复制&nbsp;</td>
  </tr>
  <tr id=cmPaste onClick ='parent.document.execCommand("Paste");parent.oPopup2.hide()'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;粘贴&nbsp;</td>
  </tr>
</table>
</div>

<DIV ID="cmTableMenu" style="display:none">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.ModifyTable();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;修改表格属性...&nbsp;</td>
  </tr>
</table>
</DIV>

<DIV ID="cmTableFunctions" style="display:none">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.ModifyCell();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;修改单元格属性...&nbsp;</td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.InsertColBefore(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;插入列(在左侧)&nbsp;</td>
  </tr>
  <tr onClick ='parent.InsertColAfter(); parent.oPopup2.hide();'> 
   <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;插入列(在右侧)&nbsp;</td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.InsertRowAbove(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;插入行(在上方)&nbsp;</td>
  </tr>
  <tr onClick ='parent.InsertRowBelow(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;插入行(在下方)&nbsp;</td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.DeleteRow(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;删除行&nbsp;</td>
  </tr>
  <tr onClick ='parent.DeleteCol(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;删除列&nbsp;</td>
  </tr>
</table>
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.IncreaseColspan(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;增加列填充&nbsp;</td>
  </tr>
  <tr onClick ='parent.DecreaseColspan(); parent.oPopup2.hide();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp减小列填充&nbsp;</td>
  </tr>
</table>
</DIV>

<DIV ID="cmImageMenu" style="display:none">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.doImage();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;修改图片属性...&nbsp;</td>
  </tr>
</table>
</DIV>

<DIV ID="cmLinkMenu" style="display:none">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.doLink();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;新建/修改链接...&nbsp;</td>
  </tr>
</table>
</DIV>

<DIV ID="cmSpellMenu" style="display:none">
<table border="0" cellspacing="0" cellpadding="3" width="160" style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: #808080 1px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: #808080 1px solid;" bgcolor="threedface">
  <tr onClick ='parent.spellCheck();'> 
    <td style="cursor:default; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" class="parent.toolbutton" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);">
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;Check Spelling...&nbsp;</td>
  </tr>
</table>
</DIV>

<!-- Start Paste Menu -->
<DIV ID="pasteMenu" STYLE="display:none">
<table border="0" cellspacing="0" cellpadding="0" width=180 style="BORDER-LEFT: buttonhighlight 1px solid; BORDER-RIGHT: buttonshadow 2px solid; BORDER-TOP: buttonhighlight 1px solid; BORDER-BOTTOM: buttonshadow 1px solid;" bgcolor="threedface">
  <tr onClick="parent.doCommand('Paste');"> 
    <td height=20 style="cursor: hand; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
&nbsp&nbsp;&nbsp;&nbsp&nbsp;粘贴&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ctrl+V </td>
  </tr>
  <tr onClick="parent.pasteWord();"> 
    <td height=20 style="cursor: hand; font:8pt tahoma; BORDER-LEFT: threedface 1px solid; BORDER-RIGHT: threedface 1px solid; BORDER-TOP: threedface 1px solid; BORDER-BOTTOM: threedface 1px solid;" onMouseOver="parent.contextHilite(this);" onMouseOut="parent.contextDelite(this);"> 
      &nbsp&nbsp;&nbsp;&nbsp&nbsp;从MS Word粘贴&nbsp;&nbsp;&nbsp;&nbsp;Ctrl+D </td>
  </tr>
</table>
</div>
<!-- End Paste Menu -->
    					</td></tr>
						<tr><td>
						<table class=iframe height=100% width=100%>
							<tr height=100%>
								<td>
									<iFrame onBlur="updateValue()" contenteditable HEIGHT=100% SECURITY="restricted" id="foo" style="width:100%;" src=''></iFrame>
									<iframe onBlur="updateValue()" id=previewFrame height=100% style="width=100%; display:none"></iframe>
								</td>
							</tr>
						</table>
						</td></tr>
						<tr><td height=1>
						<table cellpadding=0 cellspacing=0 width=100% style="background-color: threedface" class=status>
							<tr>
								<td background=/htmleditor/ew_images/status_border.gif height=22><img style="cursor:hand;" id=editTab src=/htmleditor/ew_images/status_edit_up.gif width=98 height=22 border=0 onClick=editMe()><img style="cursor:hand; " id=sourceTab src=/htmleditor/ew_images/status_source.gif width=98 height=22 border=0 onClick=sourceMe()><img style="cursor:hand; " id=previewTab src=/htmleditor/ew_images/status_preview.gif width=98 height=22 border=0 onClick=previewMe()></td>
								<td background=/htmleditor/ew_images/status_border.gif id=statusbar align=right valign=bottom><img src=/htmleditor/ew_images/button_zoom.gif width=42 height=17 valign=bottom onmouseover="button_over(this);" onmouseout="button_out(this);" onmousedown="button_down(this);" class=toolbutton onClick="showMenu('zoomMenu',65,178)"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
<script language="JavaScript">
	function setValue() {
		foo.document.write('<%=ShowContent() %>');
		foo.document.close()
	}

	function updateValue() {
		if (document.activeElement) {
			if (document.activeElement.parentElement.id == "ew") {
				return false;
			} else {
				if (parent.document.all.myEditWorksControl_html != null) {
					parent.document.all.myEditWorksControl_html.value = SaveHTMLPage();
				}
			}
		}
	}			
</script>
</textarea> <iframe id="myEditWorksControl_frame" width="100%" height="100%" frameborder="0" scrolling="auto" style="position:relative">
</iframe><input type="hidden" name="myEditWorksControl_html">
<script language="JavaScript">
	myEditWorksControl_frame.document.write(document.getElementById("myEditWorksControl_src").value)
	myEditWorksControl_frame.document.close()
	myEditWorksControl_frame.document.body.style.margin = "0px";
</script>
</td></tr></table>