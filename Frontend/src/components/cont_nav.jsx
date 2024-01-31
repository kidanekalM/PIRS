import {Link} from 'react-router-dom'
const CNav = () => {
    return ( 
        <nav className="navbar navbar-expand-lg sticky-top bg-light">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            EthioRush
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item">
              <Link to='../cdashboard'>
                <p className="nav-link active" aria-current="page"
                  >Home
                  </p>
              </Link>
              </li>
              <li className="nav-item">
              <Link to='../cprofile'>
                <p className="nav-link">Profile</p>
              </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
     );
}
 
export default CNav;