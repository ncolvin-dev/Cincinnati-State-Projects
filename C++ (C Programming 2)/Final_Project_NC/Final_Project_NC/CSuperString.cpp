// --------------------------------------------------------------------------------
// Name: CSuperString
// Abstract: Class method definitions
// --------------------------------------------------------------------------------

// --------------------------------------------------------------------------------
// Includes
// --------------------------------------------------------------------------------
#include "CSuperString.h"


// --------------------------------------------------------------------------------
// Name: Constructor
// Abstract: Default Constructor.
// --------------------------------------------------------------------------------
CSuperString::CSuperString()
{
	Initialize();

	*this = "";
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #1
// Abstract: const char*
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const char* pstrStringToCopy)
{
	Initialize();

	*this = pstrStringToCopy;
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #2
// Abstract: boolean
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const bool blnBooleanToCopy)
{
	Initialize();

	if (blnBooleanToCopy == true)
	{
		*this = "true";
	}
	else
	{
		*this = "false";
	}
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #3
// Abstract: char
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const char chrLetterToCopy)
{
	Initialize();

	*this = chrLetterToCopy;
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #4
// Abstract: short
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const short shtShortToCopy)
{
	Initialize();
	// 32767 = 5 digits + 1 for sign (+/-) + 1 for terminator + 1 for caution = 8
	char strSource[8] = "";

	sprintf_s(strSource, sizeof(strSource), "%hd", shtShortToCopy);
	
	*this = strSource;
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #5
// Abstract: int
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const int intIntegerToCopy)
{
	Initialize();

	// 	2,147,483,647 = 10 digits + 1 for sign (+/-) + 1 for terminator + 1 for caution = 13
	char strSource[13] = "";

	sprintf_s(strSource, sizeof(strSource), "%d", intIntegerToCopy);

	*this = strSource;
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #6
// Abstract: long
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const long lngLongToCopy)
{
	Initialize();

	// 	2,147,483,647 = 10 digits + 1 for sign (+/-) + 1 for terminator + 1 for caution = 13
	char strSource[13] = "";

	sprintf_s(strSource, sizeof(strSource), "%ld", lngLongToCopy);

	*this = strSource;
}



// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #6
// Abstract: float
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const float sngFloatToCopy)
{
	Initialize();

	char strSource[32] = "";

	sprintf_s(strSource, sizeof(strSource), "%g", sngFloatToCopy);

	*this = strSource;
}
 


// --------------------------------------------------------------------------------
// Name: Parameterized Constructor #7
// Abstract: double
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const double dblDoubleToCopy)
{
	Initialize();

	char strSource[64] = "";

	sprintf_s(strSource, sizeof(strSource), "%g", dblDoubleToCopy);

	*this = strSource;
}



// --------------------------------------------------------------------------------
// Name: Copy Constructor
// Abstract: Copy Constructor.
// --------------------------------------------------------------------------------
CSuperString::CSuperString(const CSuperString& ssStringToCopy)
{
	*this = ssStringToCopy.ToString();
}



	// --------------------------------------------------------------------------------
	// Name: Initialize
	// Abstract: Set class pointers to zero and then call set methods.
	// --------------------------------------------------------------------------------
	void CSuperString::Initialize()
	{
		m_pstrSuperString = 0;
	}



// --------------------------------------------------------------------------------
// Name: Length
// Abstract: How long are we?
// --------------------------------------------------------------------------------
int CSuperString::Length() const
{
	int intLength = 0;

	intLength = (int)strlen(m_pstrSuperString);

	return intLength;
}



// --------------------------------------------------------------------------------
// Name: Assignment Operator
// Abstract: const *char
// --------------------------------------------------------------------------------
void CSuperString::operator=(const char chrLetterToCopy)
{
	char strSource[2] = { chrLetterToCopy, 0 };

	*this = strSource;
}



// --------------------------------------------------------------------------------
// Name: Assignment Operator
// Abstract: const &CSuperString
// --------------------------------------------------------------------------------
void CSuperString::operator=(const CSuperString& ssStringToCopy)
{
	if (this != &ssStringToCopy)
	{
		*this = ssStringToCopy.ToString();
	}
}



// --------------------------------------------------------------------------------
// Name: Assignment Operator
// Abstract: The assignment operator.
// --------------------------------------------------------------------------------
void CSuperString::operator=(const char* pstrSource)
{
	// Self Assignment?
	if (m_pstrSuperString != pstrSource)
	{
		//No, clean up and ...
		CleanUp();

		// Deep copy
		DeepCopy(pstrSource);
	}
}



	// --------------------------------------------------------------------------------
	// Name: DeepCopy
	// Abstract: Because we have pointers to dynimically allocated memory
	//		  we must manually allocate duplicate blocks and copy all of the values
	//		  in the original blocks of memory to the copy instance. This is known
	//		  as a deep copy. The default behavior is a shallow copy.
	// --------------------------------------------------------------------------------
	void CSuperString::DeepCopy(const char* pstrSource)
	{
		m_pstrSuperString = CloneString(pstrSource);
	}



		// --------------------------------------------------------------------------------
		// Name: CloneString
		// Abstract: Make a copy of the string.
		// --------------------------------------------------------------------------------
		char* CSuperString::CloneString(const char* pstrSource) const
		{
			char* pstrClone = 0;
			int intLength = 0;

			// Null?
			if (pstrSource != 0)
			{
				// No
				intLength = strlen(pstrSource);
				pstrClone = new char[intLength + 1];
				strcpy_s(pstrClone, intLength + 1, pstrSource);
			}
			else
			{
				// Yes, default to empty string
				pstrClone = new char[1];
				*(pstrClone + 0) = 0;
			}
			return pstrClone;

		}



// --------------------------------------------------------------------------------
// Name: Assignment operator +=
// Abstract: Assignment operator +=
// --------------------------------------------------------------------------------
void CSuperString::operator+= (const char* pstrStringToAppend)
{
	int intOriginalStringSize = Length();
	int intPassedStringSize = strlen(pstrStringToAppend);
	int intNewStringSize = intOriginalStringSize + intPassedStringSize;
	char* pstrNewString = 0;

	int intPassedIndex = 0;
	int intOriginalIndex = 0;

	// Alocate new memory
	pstrNewString = new char[intNewStringSize + 1];

	// Copy values from original string
	for (intOriginalIndex = 0; intOriginalIndex < intOriginalStringSize; intOriginalIndex += 1)
	{
		*(pstrNewString + intOriginalIndex) = *(m_pstrSuperString + intOriginalIndex);
	}

	// Copy values from passed string
	for (intPassedIndex = 0; intPassedIndex < intPassedStringSize; intPassedIndex += 1)
	{
		*(pstrNewString + intOriginalIndex) = *(pstrStringToAppend + intPassedIndex);
		intOriginalIndex += 1;
	}

	// Set end of string
	*(pstrNewString + intOriginalIndex) = '\0';

	// Delete old string
	CleanUp();

	// Set new string
	m_pstrSuperString = pstrNewString;
}



// --------------------------------------------------------------------------------
// Name: Assignment operator +=
// Abstract: Assignment operator +=: const *char
// --------------------------------------------------------------------------------
void CSuperString::operator += (const char chrCharacterToAppend)
{
	char strNewString[2] = {chrCharacterToAppend, '\0'};

	// Funnel into Assignment operator +=
	*this += strNewString;
}



// --------------------------------------------------------------------------------
// Name: Assignment operator +=
// Abstract: Assignment operator +=: const CSuperString
// --------------------------------------------------------------------------------
void CSuperString::operator += (const CSuperString& ssStringToAppend)
{
	// Funnel into Assignment operator +=
	*this += ssStringToAppend.ToString();
}



// --------------------------------------------------------------------------------
// Name: Assignment operator +
// Abstract: Assignment operator +: const CSuperString, const CSuperString
// --------------------------------------------------------------------------------
CSuperString operator + (const CSuperString& ssLeft, const CSuperString& ssRight)
{
	CSuperString clsReturnInstance;

	clsReturnInstance = ssLeft;
	clsReturnInstance += ssRight;

	return clsReturnInstance;
}



// --------------------------------------------------------------------------------
// Name: Assignment operator +
// Abstract: Assignment operator +: const char*, const CSuperString
// --------------------------------------------------------------------------------
CSuperString operator + (const char* pstrLeftSide, const CSuperString& ssRightString)
{
	CSuperString clsReturnInstance(pstrLeftSide);

	clsReturnInstance += ssRightString;

	return clsReturnInstance;
}



// --------------------------------------------------------------------------------
// Name: Assignment operator +
// Abstract: Assignment operator +: const CSuperString, const char*
// --------------------------------------------------------------------------------
CSuperString operator + (const CSuperString& ssLeftString, const char* pstrRightSide)
{
	CSuperString clsReturnInstance(ssLeftString);

	clsReturnInstance += pstrRightSide;

	return clsReturnInstance;
}



//--------------------------------------------------------------------------------
// Name: operator [ ]
// Abstract: operator [ ]: char&
//--------------------------------------------------------------------------------
char& CSuperString::operator [ ] (int intIndex)
{
	int intLength = Length();

	// Validate
	if (intIndex < 0) intIndex = 0;
	if (intIndex > intLength) intIndex = intLength - 1;

	return *(m_pstrSuperString + intIndex);
}



//--------------------------------------------------------------------------------
// Name: const operator [ ]
// Abstract: operator [ ]: const char& const
//--------------------------------------------------------------------------------
const char& CSuperString::operator [ ] (int intIndex) const
{
	int intLength = Length();

	// Validate
	if (intIndex < 0) intIndex = 0;
	if (intIndex > intLength) intIndex = intLength - 1;

	return *(m_pstrSuperString + intIndex);
}



//--------------------------------------------------------------------------------
// Name: operator ==
// Abstract: operator ==: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator == (const char* pstrStringToCompare) const
{
	bool blnIsEqual = false;

	if (strcmp(m_pstrSuperString, pstrStringToCompare) == 0)
	{
		blnIsEqual = true;
	}

	return blnIsEqual;
}



//--------------------------------------------------------------------------------
// Name: operator ==
// Abstract: operator ==: const char
//--------------------------------------------------------------------------------
bool CSuperString::operator == (const char chrCharacterToCompare) const
{
	bool blnIsEqual = false;

	if (Length() == 1 && chrCharacterToCompare == m_pstrSuperString[0])
	{
		blnIsEqual = true;
	}
	
	return blnIsEqual;
}



//--------------------------------------------------------------------------------
// Name: operator ==
// Abstract: operator ==: CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator == (const CSuperString& ssStringToCompare) const
{
	bool blnIsEqual = false;

	if (strcmp(m_pstrSuperString, ssStringToCompare.m_pstrSuperString) == 0)
	{
		blnIsEqual = true;
	}

	return blnIsEqual;
}



//--------------------------------------------------------------------------------
// Name: operator !=
// Abstract: operator !=: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator != (const char* pstrStringToCompare) const
{
	bool blnIsNotEqual = false;

	if (strcmp(m_pstrSuperString, pstrStringToCompare) != 0)
	{
		blnIsNotEqual = true;
	}

	return blnIsNotEqual;
}



//--------------------------------------------------------------------------------
// Name: operator !=
// Abstract: operator !=: const char
//--------------------------------------------------------------------------------
bool CSuperString::operator != (const char chrCharacterToCompare) const
{
	bool blnIsNotEqual = false;

	if (Length() == 1 && chrCharacterToCompare != m_pstrSuperString[0])
	{
		blnIsNotEqual = true;
	}

	return blnIsNotEqual;
}



//--------------------------------------------------------------------------------
// Name: operator !=
// Abstract: operator !=: CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator != (const CSuperString& ssStringToCompare) const
{
	bool blnIsNotEqual = false;

	if (strcmp(m_pstrSuperString, ssStringToCompare.m_pstrSuperString) != 0)
	{
		blnIsNotEqual = true;
	}

	return blnIsNotEqual;
}



//--------------------------------------------------------------------------------
// Name: operator >
// Abstract: operator >: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator > (const char* pstrStringToCompare) const
{
	bool blnGreaterThan = false;
	int intStringToCompareLength = strlen(pstrStringToCompare);

	if (intStringToCompareLength > Length())
	{
		blnGreaterThan = true;
	}


	return blnGreaterThan;
}



//--------------------------------------------------------------------------------
// Name: operator >
// Abstract: operator >: const char
//--------------------------------------------------------------------------------
bool CSuperString::operator > (const char chrCharacterToCompare) const
{
	// Will always be equal, return false
	bool blnGreaterThan = false;

	return blnGreaterThan;
}



//--------------------------------------------------------------------------------
// Name: operator >
// Abstract: operator >: const CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator > (const CSuperString& ssStringToCompare) const
{
	bool blnGreaterThan = false;
	int intStringToCompareLength = ssStringToCompare.Length();

	if (intStringToCompareLength > Length())
	{
		blnGreaterThan = true;
	}


	return blnGreaterThan;
}



//--------------------------------------------------------------------------------
// Name: operator <
// Abstract: operator <: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator < (const char* pstrStringToCompare) const
{
	bool blnLessThan = false;
	int intStringToCompareLength = strlen(pstrStringToCompare);

	if (intStringToCompareLength < Length())
	{
		blnLessThan = true;
	}


	return blnLessThan;
}



//--------------------------------------------------------------------------------
// Name: operator <
// Abstract: operator <: const char
//--------------------------------------------------------------------------------
bool CSuperString::operator < (const char chrCharacterToCompare) const
{
	// Will always be equal, return false
	bool blnLessThan = false;

	return blnLessThan;
}



//--------------------------------------------------------------------------------
// Name: operator <
// Abstract: operator <: const CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator < (const CSuperString& ssStringToCompare) const
{
	bool blnLessThan = false;
	int intStringToCompareLength = ssStringToCompare.Length();

	if (intStringToCompareLength < Length())
	{
		blnLessThan = true;
	}


	return blnLessThan;
}



//--------------------------------------------------------------------------------
// Name: operator >=
// Abstract: operator >=: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator >= (const char* pstrStringToCompare) const
{
	bool blnGreaterThanEqualTo = false;
	int intStringToCompareLength = strlen(pstrStringToCompare);

	if (intStringToCompareLength >= Length())
	{
		blnGreaterThanEqualTo = true;
	}


	return blnGreaterThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator >=
// Abstract: operator >=: const char 
//--------------------------------------------------------------------------------
bool CSuperString::operator >= (const char chrCharacterToCompare) const
{
	bool blnGreaterThanEqualTo = false;
	int intCharacterToCompareLength = 1;

	if (intCharacterToCompareLength >= Length())
	{
		blnGreaterThanEqualTo = true;
	}


	return blnGreaterThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator >=
// Abstract: operator >=: const CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator >= (const CSuperString& ssStringToCompare) const
{
	bool blnGreaterThanEqualTo = false;
	int intStringToCompareLength = ssStringToCompare.Length();

	if (intStringToCompareLength >= Length())
	{
		blnGreaterThanEqualTo = true;
	}


	return blnGreaterThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator <=
// Abstract: operator <=: const char*
//--------------------------------------------------------------------------------
bool CSuperString::operator <= (const char* pstrStringToCompare) const
{
	bool blnLessThanEqualTo = false;
	int intStringToCompareLength = strlen(pstrStringToCompare);

	if (intStringToCompareLength <= Length())
	{
		blnLessThanEqualTo = true;
	}


	return blnLessThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator <=
// Abstract: operator <=: const char 
//--------------------------------------------------------------------------------
bool CSuperString::operator <= (const char chrCharacterToCompare) const
{
	bool blnLessThanEqualTo = false;
	int intCharacterLength = 1;

	if (intCharacterLength <= Length())
	{
		blnLessThanEqualTo = true;
	}


	return blnLessThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator <=
// Abstract: operator <=: const CSuperString&
//--------------------------------------------------------------------------------
bool CSuperString::operator <= (const CSuperString& ssStringToCompare) const
{
	bool blnLessThanEqualTo = false;
	int intStringToCompareLength = ssStringToCompare.Length();

	if (intStringToCompareLength <= Length())
	{
		blnLessThanEqualTo = true;
	}


	return blnLessThanEqualTo;
}



//--------------------------------------------------------------------------------
// Name: operator <<
// Abstract: operator <<: const CSuperString&
//--------------------------------------------------------------------------------
ostream& operator << (ostream& osOut, const CSuperString& ssOutput)
{
	osOut << ssOutput.m_pstrSuperString;

	return osOut;
}



//--------------------------------------------------------------------------------
// Name: operator >>
// Abstract: operator >>: const CSuperString&
//--------------------------------------------------------------------------------
istream& operator >> (istream& isIn, CSuperString& ssInput)
{
	char pstrBuffer[1000];

	isIn.get(pstrBuffer, 1000);

	ssInput = pstrBuffer;

	return isIn;
}



// --------------------------------------------------------------------------------
// Name: ToString
// Abstract: Get the string.
// --------------------------------------------------------------------------------
const char* CSuperString::ToString() const
{
	return m_pstrSuperString;
}



// --------------------------------------------------------------------------------
// Name: ToBoolean
// Abstract: Convert to a boolean.
// --------------------------------------------------------------------------------
bool CSuperString::ToBoolean() const
{
	bool blnReturnValue = false;
	if (strcmp(m_pstrSuperString, "true") == 0)
	{
		blnReturnValue = true;
	}

	return blnReturnValue;
}



// --------------------------------------------------------------------------------
// Name: ToShort
// Abstract: Convert to a short.
// --------------------------------------------------------------------------------
short CSuperString::ToShort() const
{
	int intLength = Length();
	int intValue = 0;
	short srtTotal = 0;


	// Not over integer limit?
	if (intLength <= 12)
	{
		// Yes, Convert to an int 
		intValue = std::atoi(m_pstrSuperString);
	}
	

	// Past short minimum?
	if (intValue < SHRT_MIN)
	{
		// Yes clip to the smallest number possible
		srtTotal = SHRT_MIN;
	}
	else if (intValue > SHRT_MAX) // Past short maximum?
	{
		// Yes, clip to the largest number possible
		srtTotal = SHRT_MAX;
	}
	else
	{
		// No, set the value
		srtTotal = intValue;
	}

	return srtTotal;

}



// --------------------------------------------------------------------------------
// Name: ToInteger
// Abstract: Convert to a Integer.
// --------------------------------------------------------------------------------
int CSuperString::ToInteger() const
{
	int intLength = Length();
	int intIndex = 0;
	long long llngValue = 0;
	int intTotal = 0;


	// Not over long long limit?
	if (intLength <= 20)
	{
		// Yes, Convert to a long long
		llngValue = std::atoll(m_pstrSuperString);
	}


	// Past integer minimum?
	if (llngValue < INT_MIN)
	{
		// Yes clip to the smallest number possible
		intTotal = INT_MIN;
	}
	else if (llngValue > INT_MAX) // Past integer maximum?
	{
		// Yes, clip to the largest number possible
		intTotal = INT_MAX;
	}
	else
	{
		// No, set the value
		intTotal = llngValue;
	}

	return intTotal;
}



// --------------------------------------------------------------------------------
// Name: ToLong
// Abstract: Convert to a Long.
// --------------------------------------------------------------------------------
long CSuperString::ToLong() const
{
	int intLength = Length();
	int intIndex = 0;
	long long llngValue = 0;
	long lngTotal = 0;


	// Not over long long limit?
	if (intLength <= 20)
	{
		// Yes, Convert to a long long
		llngValue = std::atoll(m_pstrSuperString);
	}

	// Past long minimum ?
	if (llngValue < LONG_MIN)
	{
		// Yes clip to the smallest number possible
		lngTotal = LONG_MIN;
	}
	else if (llngValue > LONG_MAX) // Past long maximum ?
	{
		// Yes, clip to the largest number possible
		lngTotal = LONG_MAX;
	}
	else
	{
		// No, set the value
		lngTotal = llngValue;
	}

	return lngTotal;
}



// --------------------------------------------------------------------------------
// Name: ToFloat
// Abstract: Convert to a Float.
// --------------------------------------------------------------------------------
float CSuperString::ToFloat() const
{
	int intLength = Length();
	int intIndex = 0;
	double dblValue = 0.0;
	float lngTotal = 0.0;

	// Not over double limit?
	if (intLength < 64)
	{
		// Yes, Convert to a double
		dblValue = std::atof(m_pstrSuperString);
	}

	// Past Float Minimum?
	if (dblValue < -FLT_MAX)
	{
		// Yes clip to the smallest number possible
		lngTotal = -FLT_MAX;
	}
	else if (dblValue > FLT_MAX) // Past Float Maximum?
	{
		// Yes, clip to the largest number possible
		lngTotal = FLT_MAX;
	}
	else
	{
		// No, set the value
		lngTotal = dblValue;
	}

	return lngTotal;

}



// --------------------------------------------------------------------------------
// Name: ToDouble
// Abstract: Convert to a Double.
// --------------------------------------------------------------------------------
double CSuperString::ToDouble() const
{
	int intLength = Length();
	int intIndex = 0;
	double dblValue = 0.0;
	double dblTotal = 0.0;

	// Not over double limit?
	if (intLength < 64)
	{
		// Yes, Convert to a double
		dblValue = std::atof(m_pstrSuperString);
	}

	// Past Double Minimum?
	if (dblValue < -DBL_MAX)
	{
		// Yes clip to the smallest number possible
		dblTotal = -DBL_MAX;
	}
	else if (dblValue > DBL_MAX) // Past Double Maximum?
	{
		// Yes, clip to the largest number possible
		dblTotal = DBL_MAX;
	}
	else
	{
		// No, set the value
		dblTotal = dblValue;
	}

	return dblTotal;

}



// --------------------------------------------------------------------------------
// Name: FindFirstIndexOf
// Abstract: Find the first instance of the passed character
// --------------------------------------------------------------------------------
int CSuperString::FindFirstIndexOf(const char chrLetterToFind) const
{
	int intIndex = FindFirstIndexOf(chrLetterToFind, 0);
	return intIndex;
}



// --------------------------------------------------------------------------------
// Name: FindFirstIndexOf
// Abstract: Find the first instance of the passed character
// --------------------------------------------------------------------------------
int CSuperString::FindFirstIndexOf(const char chrLetterToFind, int intStartIndex) const
{
	int intLength = Length();
	int intReturnIndex = 0;
	int intIndex = 0;
	// Loop through the string until a 
	for (intIndex = intStartIndex; intIndex < intLength; intIndex += 1)
	{
		// Equal?
		if (*(m_pstrSuperString + intIndex) == chrLetterToFind)
		{
			// Yes, Set the index and break the loop
			intReturnIndex = intIndex;
			break;
		}

	}

	return intReturnIndex;
}



// --------------------------------------------------------------------------------
// Name: FindFirstIndexOf
// Abstract: Find the first instance of the passed stringn
// --------------------------------------------------------------------------------
int CSuperString::FindFirstIndexOf(const char* pstrSubStringToFind) const
{
	int intValue = 0;
	intValue = FindFirstIndexOf(pstrSubStringToFind, 0);
	return intValue;
}



// --------------------------------------------------------------------------------
// Name: FindFirstIndexOf
// Abstract: Find the first instance of the passed string
// --------------------------------------------------------------------------------
int CSuperString::FindFirstIndexOf(const char* pstrSubStringToFind, int intStartIndex) const
{
	int intLength = Length();
	int intReturnValue = -1;
	int intBreakIndex = 0;
	int intIndex = 0;
	int intSubStringIndex = 0;
	int intSubstringLength = strlen(pstrSubStringToFind);
	bool blnFirstCharacter = true;


	// Loop through the 
	for (intIndex = intStartIndex; intIndex < intLength; intIndex += 1)
	{
		// Matching?
		if (*(pstrSubStringToFind + intSubStringIndex) == *(m_pstrSuperString + intIndex))
		{
			// Yes, Is it the first matching character?
			if (blnFirstCharacter == true)
			{
				// Yes, Set the return value
				intReturnValue = intIndex;
				blnFirstCharacter = false;
			}

			// End of substring?
			if (intSubStringIndex + 1 == intSubstringLength)
			{
				// Yes, break loop
				break;
			}

			intSubStringIndex += 1;
		}
		// No, Do values need to be reset?
		else if (blnFirstCharacter == false)
		{
			// Yes, Reset
			intSubStringIndex = 0;
			blnFirstCharacter = true;
			intReturnValue = -1;
		}
	}
	return intReturnValue;
}



// --------------------------------------------------------------------------------
// Name: FindLastIndexOf
// Abstract: Find the last instance of the passed character
// --------------------------------------------------------------------------------
int CSuperString::FindLastIndexOf(const char chrLetterToFind) const
{
	int intReturnIndex = 0;
	int intIndex = 0;
	// Loop through the string until a 
	for (intIndex = 0; intIndex < Length(); intIndex += 1)
	{
		// Equal?
		if (*(m_pstrSuperString + intIndex) == chrLetterToFind)
		{
			// Yes, Set the index
			intReturnIndex = intIndex;
		}

	}

	return intReturnIndex;
}



// --------------------------------------------------------------------------------
// Name: FindLastIndexOf
// Abstract: Find the last instance of the passed string
// --------------------------------------------------------------------------------
int CSuperString::FindLastIndexOf(const char* pstrSubStringToFind) const
{
	int intReturnValue = -1;
	int intBreakIndex = 0;
	int intIndex = 0;
	int intSubStringIndex = 0;
	int intSubstringLength = strlen(pstrSubStringToFind);
	bool blnFirstCharacter = true;



	// Loop through the 
	for (intIndex = 0; intIndex < Length(); intIndex += 1)
	{
		// Matching?
		if (*(pstrSubStringToFind + intSubStringIndex) == *(m_pstrSuperString + intIndex))
		{
			// Yes, Is it the first matching character?
			if (blnFirstCharacter == true)
			{
				// Yes, Set the return value
				intReturnValue = intIndex;
				blnFirstCharacter = false;
			}
		}
		// No, Do values need to be reset?
		else if (blnFirstCharacter == false)
		{
			// Yes, Reset
			intSubStringIndex = 0;
			blnFirstCharacter = true;
		}

	}
	return intReturnValue;
}



// --------------------------------------------------------------------------------
// Name: ToUpperCase
// Abstract: Convert the string to uppercase letters
// --------------------------------------------------------------------------------
const char* CSuperString::ToUpperCase() const
{

	int intLength = Length();
	char* pstrClone;
	int intIndex = 0;
	pstrClone = GetBuffer(m_pstrSuperString);

	// Loop through Super String
	for (intIndex = 0; intIndex < intLength; intIndex += 1)
	
		// Lowercase Letter?
	if (*(pstrClone + intIndex) >= 97 && *(pstrClone + intIndex) <= 122)
	{
		// Yes, Convert to uppercase.
		*(pstrClone + intIndex) = *(pstrClone + intIndex) - 32;
	}
	
	*(pstrClone + intIndex) = '\0';

	
	// Return Super String
	return pstrClone;

}



// --------------------------------------------------------------------------------
// Name: GetBuffer
// Abstract: Allocate and copy a string into a rotating temporary buffer.
//			 const char*
// ------------------------------------------------------------------------------
char* CSuperString::GetBuffer(const char* pstrSource) const
{
	char* pstrReturnString = 0;
	int intLength = strlen(pstrSource);

	if (pstrSource == 0)
	{
		pstrReturnString = GetBuffer(0);
	}
	else
	{
		pstrReturnString = GetBuffer(intLength);
		strcpy_s(pstrReturnString, intLength + 1, pstrSource);
	}


	return pstrReturnString;



}



	// --------------------------------------------------------------------------------
	// Name: GetBuffer
	// Abstract: Allocate and copy a string into a rotating temporary buffer.
	// ------------------------------------------------------------------------------
	char* CSuperString::GetBuffer(int intSourceSize) const
	{
		static char* apstrBuffers[2] = { 0, 0 };
		static int intCallCount = 0;
		int intBufferIndex = 0;

		// End of program?
		if (intSourceSize == -1)
		{
			// Yes, delete memory
			delete[] apstrBuffers[0];
			delete[] apstrBuffers[1];
			apstrBuffers[0] = 0;
			apstrBuffers[1] = 0;
		}
		else
		{
			// No, calculate current buffer
			intBufferIndex = intCallCount % 2;

			// Count
			intCallCount += 1;

			// Delete old memory
			delete[] apstrBuffers[intBufferIndex];

			// Alocate
			apstrBuffers[intBufferIndex] = new char[intSourceSize + 1];
		}



		return apstrBuffers[intBufferIndex];

	}




// --------------------------------------------------------------------------------
// Name: ToLowerCase
// Abstract: Convert the string to lowercase letters
// --------------------------------------------------------------------------------
const char* CSuperString::ToLowerCase() const
{
	int intLength = Length();
	char* pstrClone;
	int intIndex = 0;
	pstrClone = GetBuffer(m_pstrSuperString);

	// Loop through Super String
	for (intIndex = 0; intIndex < Length(); intIndex += 1)

		// Uppercase Letter?
		if (*(pstrClone + intIndex) >= 65 && *(pstrClone + intIndex) <= 90)
		{
			// Yes, Convert to lowercase.
			*(pstrClone + intIndex) = *(pstrClone + intIndex) + 32;
		}

	*(pstrClone + intIndex) = '\0';


	// Return Super String
	return pstrClone;
}



// --------------------------------------------------------------------------------
// Name: TrimLeft
// Abstract: Remove leading whitespace (space, tab or newline)
// --------------------------------------------------------------------------------
const char* CSuperString::TrimLeft() const
{
	int intIndex = 0;
	int intFirstNonWhitespaceIndex = -1;
	int intSourceIndex = 0;
	int intDestinationIndex = 0;
	char* pstrCopy = GetBuffer(m_pstrSuperString);

	// Default first non-whitespace character index to end of string in case string is all whitespace
	intFirstNonWhitespaceIndex = strlen(pstrCopy);

	// Find first non-whitespace character
	while (pstrCopy[intIndex] != 0)
	{
		// Non-whitespace character?
		if (IsWhiteSpace(pstrCopy[intIndex]) == false)
		{
			// Yes, save the index
			intFirstNonWhitespaceIndex = intIndex;

			// Stop searching!
			break;
		}

		// Next character
		intIndex += 1;
	}


	// Any non-whitepsace characters?
	if (intFirstNonWhitespaceIndex >= 0)
	{
		// Yes, copy everything in between
		for (intSourceIndex = intFirstNonWhitespaceIndex; intSourceIndex <= Length(); intSourceIndex += 1)
		{
			// Copy next character
			pstrCopy[intDestinationIndex] = pstrCopy[intSourceIndex];

			intDestinationIndex += 1;
		}
	}

	// Terminate 
	pstrCopy[intDestinationIndex] = 0;

	return pstrCopy;
}



// --------------------------------------------------------------------------------
// Name: TrimRight
// Abstract: Remove trailing whitespace (space, tab or newline)
// --------------------------------------------------------------------------------
const char* CSuperString::TrimRight() const
{
	int intIndex = 0;
	int intFirstNonWhitespaceIndex = -1;
	int intLastNonWhitespaceIndex = 0;
	int intSourceIndex = 0;
	int intDestinationIndex = 0;
	char* pstrCopy = GetBuffer(m_pstrSuperString);

	// Default first non-whitespace character index to end of string in case string is all whitespace
	intFirstNonWhitespaceIndex = strlen(pstrCopy);

	// Find the last non-whitespace character
	while (pstrCopy[intIndex] != 0)
	{
		// Non-whitespace character?
		if (IsWhiteSpace(pstrCopy[intIndex]) == false)
		{
			// Yes, save the index
			intLastNonWhitespaceIndex = intIndex;
		}

		// Next character
		intIndex += 1;
	}


	// Any non-whitepsace characters?
	if (intLastNonWhitespaceIndex >= 0)
	{
		intFirstNonWhitespaceIndex = 0;
		// Yes, copy everything in between
		for (intSourceIndex = intFirstNonWhitespaceIndex; intSourceIndex <= intLastNonWhitespaceIndex; intSourceIndex += 1)
		{
			// Copy next character
			pstrCopy[intDestinationIndex] = pstrCopy[intSourceIndex];

			intDestinationIndex += 1;
		}
	}

	// Terminate 
	pstrCopy[intDestinationIndex] = 0;

	return pstrCopy;
}


// --------------------------------------------------------------------------------
// Name: Trim
// Abstract: Remove leading and trailing whitespace (space, tab or newline)
// --------------------------------------------------------------------------------
const char* CSuperString::Trim() const
{
	int intIndex = 0;
	int intFirstNonWhitespaceIndex = -1;
	int intLastNonWhitespaceIndex = 0;
	int intSourceIndex = 0;
	int intDestinationIndex = 0;
	char* pstrCopy = GetBuffer(m_pstrSuperString);

	// Default first non-whitespace character index to end of string in case string is all whitespace
	intFirstNonWhitespaceIndex = strlen(pstrCopy);

	// Find first non-whitespace character
	while (pstrCopy[intIndex] != 0)
	{
		// Non-whitespace character?
		if (IsWhiteSpace(pstrCopy[intIndex]) == false)
		{
			// Yes, save the index
			intFirstNonWhitespaceIndex = intIndex;

			// Stop searching!
			break;
		}

		// Next character
		intIndex += 1;
	}

	// Find the last non-whitespace character
	while (pstrCopy[intIndex] != 0)
	{
		// Non-whitespace character?
		if (IsWhiteSpace(pstrCopy[intIndex]) == false)
		{
			// Yes, save the index
			intLastNonWhitespaceIndex = intIndex;
		}

		// Next character
		intIndex += 1;
	}

	// Any non-whitepsace characters?
	if (intFirstNonWhitespaceIndex >= 0)
	{
		// Yes, copy everything in between
		for (intSourceIndex = intFirstNonWhitespaceIndex; intSourceIndex <= intLastNonWhitespaceIndex; intSourceIndex += 1)
		{
			// Copy next character
			pstrCopy[intDestinationIndex] = pstrCopy[intSourceIndex];

			intDestinationIndex += 1;
		}
	}

	// Terminate 
	pstrCopy[intDestinationIndex] = 0;


	return pstrCopy;
}



	// --------------------------------------------------------------------------------
	// Name: IsWhiteSpace
	// Abstract: Return true if letter is a space, tab, newline or carriage return
	// --------------------------------------------------------------------------------
	bool CSuperString::IsWhiteSpace(char chrLetterToCheck) const
	{
		bool blnIsWhiteSpace = false;

		// Space
		if (chrLetterToCheck == ' ') blnIsWhiteSpace = true;

		// Tab
		if (chrLetterToCheck == '\t') blnIsWhiteSpace = true;

		// Carriarge return
		if (chrLetterToCheck == '\r') blnIsWhiteSpace = true;

		// Line feed
		if (chrLetterToCheck == '\n') blnIsWhiteSpace = true;

		return blnIsWhiteSpace;
	}



// --------------------------------------------------------------------------------
// Name: Reverse
// Abstract: Reverse the string
// --------------------------------------------------------------------------------
const char* CSuperString::Reverse() const
{
	int intLength = Length();
	int intSourceIndex = 0;
	int intCopyIndex = 0;
	char* pstrCopy = GetBuffer(intLength);

	// Loop through the string backwards
	for (intSourceIndex = intLength - 1; intSourceIndex >= 0; intSourceIndex -= 1)
	{
		*(pstrCopy + intCopyIndex) = *(m_pstrSuperString + intSourceIndex);
		intCopyIndex += 1;
	}

	// Terminate
	*(pstrCopy + intCopyIndex) = '\0';


	return pstrCopy;
}



// --------------------------------------------------------------------------------
// Name: Left
// Abstract: Return characters from the string based on given count
// --------------------------------------------------------------------------------
const char* CSuperString::Left(int intCharactersToCopy) const
{
	int intLength = Length();
	int intIndex = 0;
	char* pstrReturnString;
	// Less than zero?
	if (intCharactersToCopy < 0)
	{
		// Yes, Set return string to zero
		pstrReturnString = GetBuffer(0);
		*pstrReturnString = '\0';
	}
	else
	{
		// No, Greater than string's length?
		if (intCharactersToCopy > intLength)
		{
			// Yes, Clip to full string
			intCharactersToCopy = intLength;
		}

		// Create copy
		char* pstrCopy = GetBuffer(intCharactersToCopy);

		// Copy Characters until limit is reached
		for (intIndex = 0; intIndex < intCharactersToCopy; intIndex += 1)
		{
			*(pstrCopy + intIndex) = *(m_pstrSuperString + intIndex);
		}

		// Terminate
		*(pstrCopy + intIndex) = '\0';


		pstrReturnString = pstrCopy;
	}


	return pstrReturnString;
}



// --------------------------------------------------------------------------------
// Name: Right
// Abstract: Return characters from the string based on given count
//			 Start from the end of the string
// --------------------------------------------------------------------------------
const char* CSuperString::Right(int intCharactersToCopy) const
{
	int intLength = Length();
	int intSourceIndex = 0;
	int intDestinationIndex = 0;
	char* pstrDestination;
	char* pstrReturnString;
	// Less than zero?
	if (intCharactersToCopy < 0)
	{
		// Yes, Set return string to zero
		pstrReturnString = GetBuffer(0);
		*pstrReturnString = '\0';
	}
	else
	{
		// No, Greater than string's length?
		if (intCharactersToCopy > intLength)
		{
			// Yes, Clip to full string
			intCharactersToCopy = intLength;
		}
		
		// Create copy
		pstrDestination = GetBuffer(intCharactersToCopy);

		// Copy Characters backwards until limit is reached
		for (intSourceIndex = intCharactersToCopy - 1; intSourceIndex >= 0; intSourceIndex -= 1)
		{
			*(pstrDestination + intDestinationIndex) = *(m_pstrSuperString + intSourceIndex);
			intDestinationIndex += 1;
		}

		// Terminate
		*(pstrDestination + intDestinationIndex) = '\0';


		pstrReturnString = pstrDestination;
	}


	return pstrReturnString;
}



// --------------------------------------------------------------------------------
// Name: Substring
// Abstract: Return a substring based on given parameters
// --------------------------------------------------------------------------------
const char* CSuperString::Substring(int intStart, int intSubStringLength) const
{
	int intLength = Length();
	int intSourceIndex = 0;
	int intDestinationIndex = 0;
	char* pstrDestination;
	char* pstrReturnString;

	
	// Invalid Input?
	if (intStart < 0 || intSubStringLength < 0 || intStart >= intLength)
	{
		// Yes, return empty string
		pstrReturnString = GetBuffer(0);
		*pstrReturnString = '\0';
	}
	else
	{
		// No, Will substring go over string length?
		if (intSubStringLength + intStart > intLength)
		{
			// Yes, Clip
			intSubStringLength = intLength - intStart;
		}

		// Allocate
		pstrDestination = GetBuffer(intSubStringLength);

		// Set Starting point
		intSourceIndex = intStart;

		// Copy Characters
		for (intDestinationIndex = 0; intDestinationIndex < intSubStringLength; intDestinationIndex += 1)
		{
			*(pstrDestination + intDestinationIndex) = *(m_pstrSuperString + intSourceIndex);
			intSourceIndex += 1;

		}

		// Terminate
		*(pstrDestination + intDestinationIndex) = '\0';

		pstrReturnString = pstrDestination;
	}

	return pstrReturnString;
}



// --------------------------------------------------------------------------------
// Name: Replace
// Abstract: Replace a character based on given parameters
// --------------------------------------------------------------------------------
const char* CSuperString::Replace(char chrLetterToFind, char chrReplace)
{
	int intLength = Length();
	int intIndex = 0;
	int intReplaceStart = FindFirstIndexOf(chrLetterToFind);
	char* pstrDestination = CloneString(m_pstrSuperString);

	// Loop through string
	for (intIndex = 0; intIndex < intLength; intIndex += 1)
	{
		// Have we replaced a character yet?
		if (intIndex > intReplaceStart)
		{
			// Yes, find next character
			intReplaceStart = FindFirstIndexOf(chrLetterToFind, intIndex);
		}

		// Found character to replace?
		if (intIndex == intReplaceStart)
		{
			// Yes, replace
			*(pstrDestination + intIndex) = chrReplace;
		}

	}

	return pstrDestination;

}



// --------------------------------------------------------------------------------
// Name: Replace
// Abstract: Replace a substring based on given parameters
// --------------------------------------------------------------------------------
const char* CSuperString::Replace(const char* pstrFind, const char* pstrReplace)
{
	int intFindCount = 0;
	int intLength = Length();
	int intReplaceLength = strlen(pstrReplace);
	int intFindLength = strlen(pstrFind);
	int intDestinationLength = 0;
	int intDestinationIndex = 0;
	int intSourceIndex = 0;
	int intReplaceIndex = 0;
	int intReplaceStart = FindFirstIndexOf(pstrFind);
	char* pstrDestination;
	bool blnFlag = false;

	// Count instances of passed substring
	while (intReplaceStart > -1)
	{
		intFindCount += 1;
		intSourceIndex = intReplaceStart + intFindLength;
		intReplaceStart = FindFirstIndexOf(pstrFind, intSourceIndex);
		if (blnFlag != true)
		{
			blnFlag = true;
		}
	}

	intSourceIndex = 0;
	
	// Valid Input?
	if (blnFlag == true)
	{
		// Yes, Calculate Length of new substring
		intDestinationLength = ((intReplaceLength - intFindLength) * intFindCount) + intLength;

		// Alocate 
		pstrDestination = GetBuffer(intDestinationLength);

		// Reset
		intReplaceStart = FindFirstIndexOf(pstrFind);

		// Loop through the new substring
		while (intDestinationIndex < intDestinationLength)
		{
			// Have we replaced a substring yet?
			if (intSourceIndex > intReplaceStart && intReplaceStart != -1)
			{
				// Yes, Find next instance of substring
				intReplaceStart = FindFirstIndexOf(pstrFind, intSourceIndex);
			}

			// Start replaceing substring?
			if (intSourceIndex == intReplaceStart)
			{
				// Yes, replace substring
				for (intReplaceIndex = 0; intReplaceIndex < intReplaceLength; intReplaceIndex += 1)
				{
					*(pstrDestination + intDestinationIndex) = *(pstrReplace + intReplaceIndex);
					intDestinationIndex += 1;
				}

				// Set new location on original string
				intSourceIndex += intFindLength;
			}
			else
			{
				// No, copy character
				*(pstrDestination + intDestinationIndex) = *(m_pstrSuperString + intSourceIndex);
				intSourceIndex += 1;
				intDestinationIndex += 1;
			}
		}
	}
	else
	{
		// No, return an empty string
		pstrDestination = GetBuffer(0);
	}

	// Terminate
	*(pstrDestination + intDestinationIndex) = '\0';

	return pstrDestination;
}



// --------------------------------------------------------------------------------
// Name: Insert
// Abstract: Insert a character based on given parameters
// --------------------------------------------------------------------------------
const char* CSuperString::Insert(const char chrLetterToInsert, int intIndex)
{
	int intLength = Length();
	int intDestinationIndex = 0;
	int intSourceIndex = 0;
	char* pstrDestination = GetBuffer(intLength + 1);

	// Boundry Check
	if (intIndex < 0) intIndex = 0;
	if (intIndex > intLength) intIndex = intLength;

		// Loop through new string
		for (intDestinationIndex = 0; intDestinationIndex < intLength + 1; intDestinationIndex += 1)
		{
			// Equal?
			if(intDestinationIndex == intIndex)
			{
				// Yes, insert character 
				*(pstrDestination + intDestinationIndex) = chrLetterToInsert;
			}
			else
			{
				// No, copy character
				*(pstrDestination + intDestinationIndex) = *(m_pstrSuperString + intSourceIndex);
				intSourceIndex += 1;
			}
		}

		*(pstrDestination + intDestinationIndex) = '\0';


	return pstrDestination;

}



// --------------------------------------------------------------------------------
// Name: Insert
// Abstract: Insert a substring based on given parameters
// --------------------------------------------------------------------------------
const char* CSuperString::Insert(const char* pstrSubString, int intIndex)
{
	int intLength = Length();
	int intInsertLength = strlen(pstrSubString);
	int intDestinationLength = intLength + intInsertLength;
	int intDestinationIndex = 0;
	int intSourceIndex = 0;
	int intInsertIndex = 0;

	char* pstrDestination = GetBuffer(intDestinationLength);


	// Boundry Check 
	if (intIndex < 0) intIndex = 0;
	if (intIndex > intLength) intIndex = intLength;

	while (intDestinationIndex < intDestinationLength)
	{
		if(intDestinationIndex == intIndex)
		{
			for (intInsertIndex = 0; intInsertIndex < intInsertLength; intInsertIndex += 1)
			{
				*(pstrDestination + intDestinationIndex) = *(pstrSubString + intInsertIndex);
				intDestinationIndex += 1;

			}
		}
		else
		{
			*(pstrDestination + intDestinationIndex) = *(m_pstrSuperString + intSourceIndex);
			intDestinationIndex += 1;
			intSourceIndex += 1;
		}

	}
	*(pstrDestination + intDestinationIndex) = '\0';

	return pstrDestination;

}



// --------------------------------------------------------------------------------
// Name: Print
// Abstract: Print all the string with caption. Makes Testing easier
// --------------------------------------------------------------------------------
void CSuperString::Print(const char* pstrCaption) const
{
	// Caption
	cout << endl;
	cout << pstrCaption << endl;
	cout << "-----------------------------------------------" << endl;

	// Length not 0?
	if (Length() > 0)
	{
		// Yes, print string
		cout << m_pstrSuperString << endl;
	}
	else
	{
		// No, print empty string
		cout << "-Empty string" << endl;
	}
}




// --------------------------------------------------------------------------------
// Name: Destructor
// Abstract: Goodbye, cruel world.
// --------------------------------------------------------------------------------
CSuperString::~CSuperString()
{
	CleanUp();
	GetBuffer(-1);
}



	// --------------------------------------------------------------------------------
	// Name: CleanUp
	// Abstract: Every call to new must be paired with a call to delete
	// --------------------------------------------------------------------------------
	void CSuperString::CleanUp()
	{
		DeleteString(m_pstrSuperString);
	}



		// --------------------------------------------------------------------------------
		// Name: DeleteString
		// Abstract: Delete the string and assign the pointer to zero
		// --------------------------------------------------------------------------------
		void CSuperString::DeleteString(char*& pstrSource)
		{
			// Null?
			if (pstrSource != 0)
			{
				// No, delete string
				delete[] pstrSource;
				// Set pointer to zero
				pstrSource = 0;

			}
		}

