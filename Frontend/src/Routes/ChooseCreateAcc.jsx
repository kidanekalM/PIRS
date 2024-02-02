import { Link } from "react-router-dom";
const ChooseAccount = () => {
    return ( 
        <>
            <div className="row">
                <div className="col border"><Link to="../signupasuser"><button className="btn">User</button></Link></div>
                <div className="col border"><Link to="../signupascontractor"><button className="btn">Contractor</button></Link></div>
                <div className="col border"><Link to="../signupascompany"><button className="btn">Company</button></Link></div>
            </div>
        </>
     );
}
 
export default ChooseAccount;