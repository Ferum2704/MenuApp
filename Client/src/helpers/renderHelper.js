import { REQUEST_STATUSES } from "../constants/apiRequestStatus";
import Spinner from "react-bootstrap/Spinner";

export function renderResultByStatus(status, error, successResult) {
  switch (status) {
    case REQUEST_STATUSES.loading:
      return (
        <div>
          <Spinner
            as="span"
            animation="border"
            size="sm"
            role="status"
            aria-hidden="true"
          />
          Loading...
        </div>
      );
    case REQUEST_STATUSES.succeeded:
      return successResult;
    case REQUEST_STATUSES.failed:
      return <div className="error">{error}</div>;
    default:
      break;
  }
}
