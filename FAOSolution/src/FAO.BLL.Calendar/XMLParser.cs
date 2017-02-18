using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.BLL.Calendar
{
    public enum xpNodeType { xpTopNode, xpStandalone, xpParent, xpSubNode, xpSibbling, xpEndNode } ;
    public enum cbrType { cbr_OK, cbr_NoChildren, cbr_Abort } ;


    public class XMLParser
    {
        public delegate cbrType ParserCallbackFn(BAFASCycleObject value, xpNodeType nodeType, string Name, string Attrs, string Xml);

        ParserCallbackFn m_callback;
        BAFASCycleObject m_value;

        public XMLParser()
        {

        }

        public void SetCallback(ParserCallbackFn setTo, BAFASCycleObject value)
        {
            m_callback = setTo;
            m_value = value;
        }

        public bool ParseXML(string xml)
        {
            string tmp;
            string outString;
            string rest;
            bool hr;

            //
            // If empty, return failure.
            //
            if ( xml == null || xml[0] == 0 )
                return false;

            //
            // Make a copy of the string.  This copy will be modified.
            //
            tmp = xml;
            //
            // Now we need to start processing the XML string.
            //
            rest = tmp;
            //
            // Now we need to process the node.
            //
            if (!(hr = ProcessNode(rest, xpNodeType.xpTopNode, out outString)))
		        return hr;
            return true;
        }

        bool EatSpace(string inString, out string outString, ref int outIndex)
        {
            int i = 0;

            outString = null;
            if (inString == null)
                return false;

            while (inString[i] == 32 || inString[i] == 9 || inString[i] == 10 || inString[i] == 13)
            {
                i++;
                outIndex++;
            }
            outString = inString.Substring(i, inString.Length - i);
            if (inString[i] == 0)
                return false;
            return true;
        }

        bool GetName(string inString, out string name, out string outString, ref int outIndex)
        {
            int i = 0;
            bool hr;

            name = null;
            outString = null;
            hr = EatSpace(inString, out inString, ref outIndex);
            if (hr != true)
                return hr;
            name = inString;
            while ((inString[i] >= 'a' && inString[i] <= 'z') || (inString[i] >= 'A' && inString[i] <= 'Z') ||
                   (inString[i] >= '0' && inString[i] <= '9') || inString[i] == '_' || inString[i] == '-')
            {
                i++;
                outIndex++;
            }
            outString = inString.Substring(i, inString.Length - i);
            if (inString[i] == 0)
                return false;
            else if (inString[i] == '=')
            {
                i++;
                outString = inString.Substring(i, inString.Length - i);
                return true;
            }
            else
                throw new Exception("Improperly formatted string");
        }

        bool GetNodeName (string inString, out string name, out string outString, ref int outIndex)
        {
            int i = 0;
            bool hr;
	        string nm;

            hr = EatSpace(inString, out inString, ref outIndex);
            name = null;
            outString = null;
            if ( hr != true )
	        {
                return false;
	        }

	        nm = "";
            while ((inString[i] >= 'a' && inString[i] <= 'z') || (inString[i] >= 'A' && inString[i] <= 'Z') ||
                   (inString[i] >= '0' && inString[i] <= '9') ||  inString[i] == '_' || inString[i] == '-')
	        {
		        outIndex++;
                i++;
	        }
            nm = inString.Substring(0, i);
	        name = nm;

            outString = inString.Substring(i, inString.Length - i);
            if (inString[i] == 0)
                return false;
            else 
            {
                return true;
            }
        }

        bool GetValue(string inString, out string value, out string outString, ref int outIndex)
        {
            int i = 0;

            value = null;
            outString = null;

            if (inString[i] != '"')
                throw new Exception("Improperly formatted string");

            i++;
            outIndex++;
            value = inString.Substring(i, inString.Length - i);
            while (inString[i] != '"' && inString[i] != 0)
            {
                i++;
                outIndex++;
            }
            outString = inString.Substring(i, inString.Length - i);
            if (inString[i] == 0)
                return false;
            else if (inString[i] == '"')
            {
                i++;
                outIndex++;
                outString = inString.Substring(i, inString.Length - i);
                return true;
            }
            else
                throw new Exception("Improperly formatted string");
        }

        bool EatAttrList(string inString, out string outString, ref int outIndex)
        {
	        bool hr;
	        string tmp;

	        do
	        {
                hr = GetName(inString, out tmp, out outString, ref outIndex);
		        if ( hr == true )
		        {
			        inString = outString;
                    hr = GetValue(inString, out tmp, out outString, ref outIndex);
			        if ( hr == true )
			        {
				        inString = outString;
			        }
		        }
		        else 
			        return true;
	        } 
	        while (hr == true);
	        return hr;
        }

        bool ProcessNode (string inString, xpNodeType nodeType, out string outString )
        {
	        bool hr;
	        string node;
	        string attrList;
	        int index = 0;
	        string name;
	        int attrStart;
	        char tmpChar;
	        cbrType res;
	        bool hasChildren;
	        int nodeEnd = 0;
	        int nodeCloseStart = 0;

            outString = string.Empty;
	        if ( outString == null )
		        return false;
	        do 
	        {
		        node = string.Empty;
		        attrList = string.Empty;
		        //
		        // First eat the spaces (if any) (ignore index)
		        //
		        hr = EatSpace(inString, out outString, ref index);
		        if ( hr != true )
		        {
                    return false;
                }

		        inString = outString;
		        if ( inString[0] == '<' && inString[1] == '/' )
			        break;

		        if ( inString[0] != '<' )
			        return false;

		        index = 1; // set index to beginning of node string;
		        node = inString; // save the original string;
		        inString = inString.Substring(1, inString.Length - 1);

		        name = string.Empty;
		        hr = GetNodeName(inString, out name, out outString, ref index);
		        if ( hr != true )
			        return false;

		        inString = outString;

		        hr = EatSpace(inString, out outString, ref index);
		        if ( hr != true )
		        {
                    return  false;
                }

		        inString = outString;
		        //
		        // Now get the attribute string.
		        //
		        attrStart = index;
		        hr = EatAttrList (inString, out outString, ref index);
		        if ( hr != true )
			        return hr;

		        // Save the old node character.
		        tmpChar = node[index];
		        // Make the character after the attribute string into a zero
                StringBuilder sb = new StringBuilder(node);
                sb[index] = Convert.ToChar(0);
		        node = sb.ToString();

		        // Get the attribute string
		        attrList = node.Substring(attrStart, inString.Length - attrStart);
		        // Restore the old character.
                sb = new StringBuilder(node);
                sb[index] = Convert.ToChar(tmpChar);
		        node = sb.ToString();
		
		        inString = outString;

		        // Now eat any spaces.
		        hr = EatSpace(inString, out outString, ref index);
		        if ( hr != true )
		        {
			        return false;
		        }
		        inString = outString;
		
		        nodeEnd = 0;
		        // Now we can check to see if this is a self contained node, or a parent node.
		        if (inString[0] == '/' && inString[1] == '>')
		        {
			        // Save the old node character.
			        tmpChar = node[index + 2];
			        // Make the character after the attribute string into a zero
                    sb = new StringBuilder(node);
                    sb[index  + 2] = Convert.ToChar(0);
		            node = sb.ToString();			

			        //
			        // Now we have the information for this node.  Call the callback function
			        //
			        res = m_callback(m_value, (nodeType == xpNodeType.xpTopNode ? nodeType : xpNodeType.xpStandalone), name, attrList, node);

			        // Restore the old character.
                    sb = new StringBuilder(node);
                    sb[index  + 2] = Convert.ToChar(tmpChar);
		            node = sb.ToString();			
			        hasChildren = false;
			        index += 2;
			        inString = inString.Substring(2, inString.Length - 2);
		        }
		        else if(inString[0] == '>')
		        {
			        hr = FindEndNode (node, ref nodeEnd, ref nodeCloseStart);
			        if ( !hr )
				        return hr;

			        // Save the old node character.
			        tmpChar = node[nodeEnd];
			        // Make the character after the attribute string into a zero
                    sb = new StringBuilder(node);
                    sb[nodeEnd] = Convert.ToChar(0);
		            node = sb.ToString();			

			        //
			        // Now we have the information for this node.  Call the callback function
			        //
			        res = m_callback(m_value, nodeType, name, attrList, node);

			        // Restore the old character.
                    sb = new StringBuilder(node);
                    sb[nodeEnd] = Convert.ToChar(tmpChar);
		            node = sb.ToString();			
			        hasChildren = true;
			        index++;
			        inString = inString.Substring(1, inString.Length - 1);
		        }
		        else
			        return false;

		        //
		        // Now, if this node has children and the callback did not tell us to skip them,
		        // recursively process the children nodes.
		        //
                if (res == cbrType.cbr_OK && hasChildren)
		        {
                    hr = ProcessNode(inString, xpNodeType.xpParent, out outString);
			        if ( !hr )
				        return hr;
		        }
		        if ( hasChildren )
		        {
			        inString = inString.Substring(nodeEnd, inString.Length - nodeEnd);
		        }
	        }
            while (nodeType != xpNodeType.xpTopNode && hr == true && res != cbrType.cbr_Abort);
	        return hr;	
        }

        bool FindEndNode (string inString,  ref int nodeEnd, ref int nodeCloseStart)
        {
	        string outString;

	        return FindEndSubNode (true, inString, out outString, ref nodeEnd, ref nodeCloseStart);
        }

        bool FindEndSubNode (bool isTopNode, string inString, out string outString, ref int nodeEnd, ref int nodeCloseStart)
        {
	        bool hr;
	        string name;
	        string name2;
	        bool hasChildren;

            outString = string.Empty;
	        do 
	        {
		        //
		        // First eat the spaces (if any) (ignore index)
		        //
		        hr = EatSpace(inString, out outString, ref nodeEnd);
		        if ( hr != true )
		        {
			        return hr;
		        }

		        inString = outString;
		        if ( inString[0] == '<' && inString[1] == '/' )
		        {
			        nodeCloseStart = nodeEnd;
			        return true;
		        }
		        if ( inString[0] != '<' )
			        return false;

		        inString = inString.Substring(1, inString.Length - 1);
		        nodeEnd++;

		        name = string.Empty;
		        hr = GetNodeName(inString, out name, out outString, ref nodeEnd);
		        if ( hr != true )
			        return false;

		        inString = outString;
		        //
		        // Now get the attribute string.
		        //
		        hr = EatAttrList (inString, out outString, ref nodeEnd);
		        if ( !(hr) )
			        return hr;
		        inString = outString;

		        // Now eat any spaces.
		        hr = EatSpace(inString, out outString, ref nodeEnd);
		        if ( hr != true )
		        {
			        return hr;
		        }
		        inString = outString;
		
		        // Now we can check to see if this is a self contained node, or a parent node.
		        if (inString[0] == '/' && inString[1] == '>')
		        {
			        nodeEnd += 2;
                    inString = inString.Substring(2, inString.Length - 2);
			        hasChildren = false;
		        }
		        else if (inString[0] == '>')
		        {
			        nodeEnd++;
			        hr = FindEndSubNode (false, Convert.ToString(inString[1]), out outString, ref nodeEnd, ref nodeCloseStart);
			        if ( !(hr) )
				        return hr;
			        inString = outString;
			        hasChildren = true;
		        }
		        else
			        return false;

		        if ( hasChildren )
		        {
			        hr = EatSpace(inString, out outString, ref nodeEnd);
			        if ( hr != true )
			        {
				        return hr;
			        }
			        inString = outString;
			        if (inString[0] != '<' || inString[1] != '/')
				        return false;
			        nodeCloseStart = nodeEnd;
			        nodeEnd += 2;
			        inString = inString.Substring(2, inString.Length - 2);

			        name2 = string.Empty;
			        hr = GetNodeName(inString, out name2, out outString, ref nodeEnd);
			        if ( hr != true )
				        return false;
			        inString = outString;

			        if ( string.Compare(name, name2) != 0 )
				        return false;

			        hr = EatSpace(inString, out outString, ref nodeEnd);
			        if ( hr != true )
			        {
				        return hr;
			        }
			        inString = outString;

			        if (inString[0] != '>')
				        return false;
			        inString = inString.Substring(1, inString.Length - 1);
			        nodeEnd++;
		        }
	        }
	        while (!isTopNode && hr == true);
	        return hr;
        }

    }
}
