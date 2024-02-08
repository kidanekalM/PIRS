import ReportCard from "../../components/Report/report_card";
import React, { useEffect, useState } from 'react';


const ContReport = ({companyId}) => {
  const [report, setReport] = useState(null);

  useEffect(() => {
    
      fetch(`https://localhost:7077/Report/GetByCompany/${companyId}`)
        .then((response) => response.json())
        .then((data) => {setReport(data);
        console.log(report)
        })
        
    }, [companyId]);

  return (
    <div>
      {report && <ReportCard report={report} />}
    </div>
  );
};

export default ContReport;